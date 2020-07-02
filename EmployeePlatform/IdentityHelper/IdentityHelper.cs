using EmployeePlatform.Entities;
using EmployeePlatform.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;

namespace EmployeePlatform
{
    public class IdentityHelper : IIdentityHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal CreateIdentity(string Name, string Role, AuthenticateResponseDTO user)
        {
            var Claims = new Dictionary<string, string>();
            Claims.Add(ClaimTypes.NameIdentifier, user.Id.ToString());
            Claims.Add(ClaimTypes.Name, user.Token.ToString());
            Claims.Add(ClaimTypes.Role, user.Role.ToString());

            var identity = new ClaimsIdentity("EmployeePlatformKeySecret", Name, Role);

            identity.AddClaim(new Claim("UserName", Name));
            if (Claims != null)
            {
                foreach (var key in Claims.Keys)
                {
                    identity.AddClaim(new Claim(key, Claims[key]));
                }
            }

            return new ClaimsPrincipal(identity);
        }

        public string GetCurrentToken()
        {
            return _httpContextAccessor.HttpContext.Session.GetString("JWToken");
        }
    }
}
