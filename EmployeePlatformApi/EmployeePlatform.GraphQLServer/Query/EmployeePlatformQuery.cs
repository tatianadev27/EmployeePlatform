using EmployeePlatform.Business;
using EmployeePlatform.GraphQLServer.Helpers;
using EmployeePlatform.GraphQLServer.Types;
using GraphQL.Types;
using System.Collections.Generic;

namespace EmployeePlatform.GraphQLServer.Query
{
    public class EmployeePlatformQuery : ObjectGraphType
    {
        public EmployeePlatformQuery(ContextServiceLocator contextServiceLocator)
        {
            FieldAsync<ListGraphType<AreaType>>(
                "areas",
                resolve: async context =>
                {
                    return await new AreaBL(contextServiceLocator.AreaRepository).GetAll();
                }
            );
            FieldAsync<ListGraphType<SubareaType>>(
                "subareas",
                resolve: async context =>
                {
                    return await new SubareaBL(contextServiceLocator.SubareaRepository).GetAll();
                }
            );
            FieldAsync<ListGraphType<SubareaType>>(
                "subareasByArea",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<NonNullGraphType<IntGraphType>>
                    {
                        Name = "idArea"
                    }
                }),
                resolve: async context =>
                {
                    return await new SubareaBL(contextServiceLocator.SubareaRepository).GetAllForArea(context.GetArgument<int?>("idArea").Value);
                }
            );
            FieldAsync<ListGraphType<IdentificationTypesType>>(
                "identificationTypes",
                resolve: async context =>
                {
                    return await new IdentificationTypeBL(contextServiceLocator.identificationTypeRepository).GetAll();
                }
            );
            FieldAsync<EmployeePaginateType>(
               "employees",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<NonNullGraphType<IntGraphType>>
                    {
                        Name = "pageSize"
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "filter"
                    }
                }),
                resolve: async context =>
                {

                    var userContext = context.UserContext;
                    return await new PaginationBL(contextServiceLocator.paginationRepository)
                    .GetPaginationData(
                        pageSize: context.GetArgument<int?>("pageSize").Value,
                        filter: context.GetArgument<string>("filter")
                        );
                }
            );
            FieldAsync<EmployeeType>(
               "employee",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<NonNullGraphType<IntGraphType>>
                    {
                        Name = "id"
                    }
                }),
                resolve: async context =>
                {

                    var userContext = context.UserContext;
                    return await new EmployeeBL(contextServiceLocator.employeeRepository)
                    .GetById(
                        id: context.GetArgument<int?>("id").Value
                        );
                }
            );
            FieldAsync<ListGraphType<EmployeeType>>(
               "employeesFilter",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                    {
                        Name = "filter",
                        Description = "Filter for FirstName, LastName or IdentificationNumber",
                        DefaultValue = null
                    }
                }),
                 resolve: async context =>
                 {
                     return await new EmployeeBL(contextServiceLocator.employeeRepository)
                     .GetAll(filter: context.GetArgument<string>("filter"));
                 }
            );
            //.AuthorizeWith(Policies.Admin)            
        }
    }
}