
using EmployeePlatform.DataAccess.Repositories.Contracts;
using EmployeePlatform.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePlatform.GraphQLServer
{
    public class Auth
    {



        public async Task<AuthenticateResponseDTO> Authenticate(UserDTO entity, JwtSecurityTokenHandler jwtSecurityTokenHandler, IUserRepository userRepository)
        {
            UserDTO user = await userRepository.GetByEmail(entity.Email);

            // return null if user not found
            if (user == null || !BCrypt.Net.BCrypt.Verify(entity.Password, user.Password)) return null;

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user, jwtSecurityTokenHandler);

            return new AuthenticateResponseDTO()
            {
                ExpiredToken = token.Item2,
                Token = token.Item1,
                Id = user.Id,
                Role = user.Role,
                Email = user.Email
            };
        }

        private Tuple<string, DateTime> GenerateJwtToken(UserDTO user, JwtSecurityTokenHandler jwtSecurityTokenHandler)
        {
            // generate token that is valid for 7 days
            var tokenHandler = jwtSecurityTokenHandler;
            var key = Encoding.ASCII.GetBytes("EmployeePlatformWebAuth");
            var expires = DateTime.UtcNow.AddMinutes(210);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Tuple.Create(tokenHandler.WriteToken(token), expires);
        }
    }
}
