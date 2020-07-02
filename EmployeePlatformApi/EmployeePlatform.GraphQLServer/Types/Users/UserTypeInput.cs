using EmployeePlatform.Database.Models;
using EmployeePlatform.Entities;
using GraphQL.Types;

namespace EmployeePlatform.GraphQLServer.Types
{
    public class SignupTypeInput : InputObjectGraphType<UserDTO>
    {
        public SignupTypeInput()
        {
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.IdentificationNumber);
            Field(x => x.Email);
            Field(x => x.Password);
            Field(x => x.Role);
        }
    }

    public class LoginTypeInput : InputObjectGraphType<UserDTO>
    {
        public LoginTypeInput()
        {
            Field(x => x.Email);
            Field(x => x.Password);
        }
    }
}
