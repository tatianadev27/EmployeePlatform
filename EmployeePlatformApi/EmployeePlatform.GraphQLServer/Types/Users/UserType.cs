using EmployeePlatform.Entities;
using GraphQL.Types;

namespace EmployeePlatform.GraphQLServer.Types
{
    public class UserType : ObjectGraphType<UserDTO>
    {
        public UserType()
        {
            Field(x => x.Id);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.IdentificationNumber);
            Field(x => x.CreatedAt);
            Field(x => x.CreatedBy);
            Field(x => x.ModifiedAt);
            Field(x => x.ModifiedBy);
            Field(x => x.Email);
            Field(x => x.Password);
            Field(x => x.Role);
        }
    }

    public class UserResponseAuthenticateType : ObjectGraphType<AuthenticateResponseDTO>
    {
        public UserResponseAuthenticateType()
        {
            Field(x => x.Id);
            Field(x => x.ExpiredToken);
            Field(x => x.Token);
            Field(x => x.Email);
            Field(x => x.Role);
        }
    }
}
