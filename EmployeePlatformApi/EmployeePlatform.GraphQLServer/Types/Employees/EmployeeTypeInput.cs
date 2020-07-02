using EmployeePlatform.Database.Models;
using EmployeePlatform.Entities;
using GraphQL.Types;

namespace EmployeePlatform.GraphQLServer.Types
{
    public class EmployeeTypeInput : InputObjectGraphType<EmployeeDTO>
    {
        public EmployeeTypeInput()
        {
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.IdentificationNumber);
            Field(x => x.IdentificationTypeId);
            Field(x => x.SubareaId);
        }
    }

    public class EmployeeTypeUpdateInput : InputObjectGraphType<EmployeeDTO>
    {
        public EmployeeTypeUpdateInput()
        {
            Field(x => x.Id);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.IdentificationNumber);
            Field(x => x.IdentificationTypeId);
            Field(x => x.SubareaId);
        }
    }
}
