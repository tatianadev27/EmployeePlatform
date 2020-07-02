using Autofac;
using EmployeePlatform.DataAccess.Repositories;
using EmployeePlatform.DataAccess.Repositories.Contracts;
using EmployeePlatform.GraphQLServer.Helpers;
using EmployeePlatform.GraphQLServer.Mutations;
using EmployeePlatform.GraphQLServer.Query;
using EmployeePlatform.GraphQLServer.Types;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;

namespace EmployeePlatform.GraphQLServer.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HttpContextAccessor>().AsImplementedInterfaces();
            builder.Register(c => new DocumentWriter(false)).AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<DocumentExecuter>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<ContextServiceLocator>().SingleInstance();
            builder.RegisterType<EmployeePlatformSchema>().As<ISchema>().SingleInstance();
            builder.RegisterType<DocumentExecuter>().As<IDocumentExecuter>().SingleInstance();
            builder.RegisterType<EmployeePlatformQuery>().SingleInstance();
            builder.RegisterType<EmployeePlatformMutation>().SingleInstance();
            builder.RegisterType<AreaType>().SingleInstance();
            builder.RegisterType<SubareaType>().SingleInstance();
            builder.RegisterType<IdentificationTypesType>().SingleInstance();
            builder.RegisterType<EmployeePaginateType>().SingleInstance();
            builder.RegisterType<EmployeeType>().SingleInstance();
            builder.RegisterType<EmployeeTypeInput>();
            builder.RegisterType<EmployeeTypeUpdateInput>();
            builder.RegisterType<UserType>();
            builder.RegisterType<UserResponseAuthenticateType>();
            builder.RegisterType<SignupTypeInput>();
            builder.RegisterType<LoginTypeInput>();
            builder.Register(c =>
            {
                var cc = c.Resolve<IComponentContext>();
                var dependencyResolver = new FuncDependencyResolver(type => cc.Resolve(type));
                return new EmployeePlatformSchema(dependencyResolver);
            }).AsSelf().AsImplementedInterfaces().SingleInstance();


            builder.RegisterType<AreaRepository>().As<IAreaRepository>();
            builder.RegisterType<SubareaRepository>().As<ISubareaRepository>();
            builder.RegisterType<IdentificationTypeRepository>().As<IIdentificationTypeRepository>();
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<PaginationRepository>().As<IPaginationRepository>();
        }
    }
}