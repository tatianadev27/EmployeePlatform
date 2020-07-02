using GraphQL.Types;
using EmployeePlatform.Database.Models;
using System.Collections.Generic;
using EmployeePlatform.DataAccess.Repositories;
using EmployeePlatform.Database;
using EmployeePlatform.Entities;

namespace EmployeePlatform.GraphQLServer.Types
{
    public class IdentificationTypesType : ObjectGraphType<IdentificationTypeDTO>
    {
        public IdentificationTypesType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.CreatedAt);
            Field(x => x.CreatedBy);
            Field(x => x.ModifiedAt);
            Field(x => x.ModifiedBy);
        }
    }
}
