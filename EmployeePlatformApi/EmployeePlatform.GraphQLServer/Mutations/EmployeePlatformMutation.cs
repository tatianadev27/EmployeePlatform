using EmployeePlatform.Business;
using EmployeePlatform.Database.Models;
using EmployeePlatform.Entities;
using EmployeePlatform.GraphQLServer.Common;
using EmployeePlatform.GraphQLServer.Helpers;
using EmployeePlatform.GraphQLServer.Types;
using GraphQL.Authorization;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace EmployeePlatform.GraphQLServer.Mutations
{
    public class EmployeePlatformMutation : ObjectGraphType
    {
        public EmployeePlatformMutation(ContextServiceLocator contextServiceLocator,  JwtSecurityTokenHandler jwtSecurityTokenHandler)
        {
            FieldAsync<EmployeeType>(
                "createEmployee",
                 arguments: new QueryArguments(new QueryArgument<NonNullGraphType<EmployeeTypeInput>> { Name = "input" }),
                resolve: async context =>
                {
                    EmployeeDTO entity = context.GetArgument<EmployeeDTO>("input");
                    entity.CreatedAt = DateTime.Now;
                    entity.ModifiedAt = DateTime.Now;
                    var userContext = context.UserContext;
                    entity.CreatedBy = entity.FirstName;
                    entity.ModifiedBy = entity.FirstName;
                    return await new EmployeeBL(contextServiceLocator.employeeRepository).Add(entity);
                });
            //.AuthorizeWith(Policies.Admin); 
            FieldAsync<EmployeeType>(
                "updateEmployee",
                 arguments: new QueryArguments(new QueryArgument<NonNullGraphType<EmployeeTypeUpdateInput>> { Name = "input" }),
                resolve: async context =>
                {
                    EmployeeDTO entity = context.GetArgument<EmployeeDTO>("input");
                    entity.ModifiedAt = DateTime.Now;
                    entity.ModifiedBy = entity.FirstName;
                    return await new EmployeeBL(contextServiceLocator.employeeRepository).Update(entity);
                });
                //.AuthorizeWith(Policies.Admin); 
            FieldAsync<UserType>(
                "signup",
                 arguments: new QueryArguments(new QueryArgument<NonNullGraphType<SignupTypeInput>> { Name = "input" }),
                resolve: async context =>
                {
                    UserDTO entity = context.GetArgument<UserDTO>("input");
                    entity.CreatedAt = DateTime.Now;
                    entity.ModifiedAt = DateTime.Now;
                    entity.CreatedBy = entity.FirstName;
                    entity.ModifiedBy = entity.FirstName;
                    entity.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password);
                    return await new UserBL(contextServiceLocator.userRepository).Add(entity);
                }).AuthorizeWith(Policies.Admin);
            FieldAsync<UserResponseAuthenticateType>(
                "login",
                 arguments: new QueryArguments(new QueryArgument<NonNullGraphType<LoginTypeInput>> { Name = "input" }),
                resolve: async context =>
                {
                    UserDTO entity = context.GetArgument<UserDTO>("input");
                    return await new Auth().Authenticate(entity, jwtSecurityTokenHandler, contextServiceLocator.userRepository);
                });
        }
    }

}
