using EmployeePlatform.Business;
using EmployeePlatform.Entities;
using EmployeePlatform.GraphQLServer.Helpers;
using GraphQL.Types;
using System.Collections.Generic;

namespace EmployeePlatform.GraphQLServer.Types
{
    public class EmployeePaginateType : ObjectGraphType<PaginationDTO>
    {
        public EmployeePaginateType(ContextServiceLocator contextServiceLocator)
        {
            Field(x => x.TotalPages);
            Field(x => x.TotalRecords);
            Field(x => x.Error);
            FieldAsync<ListGraphType<EmployeeType>>("results",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<NonNullGraphType<IntGraphType>>
                    {
                        Name = "pageSize"
                    },
                    new QueryArgument<NonNullGraphType<IntGraphType>>
                    {
                        Name = "page"
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "filter",
                        Description = "Filter for Name and IdentificationNumber",
                        DefaultValue = null
                    }
                }),
                 resolve: async context =>
                 {
                     return await new EmployeeBL(contextServiceLocator.employeeRepository)
                     .GetAll(
                         pageSize: context.GetArgument<int?>("pageSize").Value,
                         page: context.GetArgument<int?>("page").Value,
                         filter: context.GetArgument<string>("filter"));
                 }
             );
        }
    }
}
