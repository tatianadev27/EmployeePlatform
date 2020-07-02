using EmployeePlatform.GraphQLServer.Mutations;
using EmployeePlatform.GraphQLServer.Query;
using EmployeePlatform.GraphQLServer.Types;
using GraphQL;
using GraphQL.Types;

namespace EmployeePlatform.GraphQLServer
{
    public class EmployeePlatformSchema : Schema
    {
        public EmployeePlatformSchema()
        {
            RegisterType<AreaType>();
            RegisterType<SubareaType>();
            RegisterType<IdentificationTypesType>();
            RegisterType<EmployeeType>();
            RegisterType<EmployeePaginateType>();
            RegisterType<EmployeeTypeInput>();
            RegisterType<EmployeeTypeUpdateInput>();
            RegisterType<UserType>();
            RegisterType<UserResponseAuthenticateType>();
            RegisterType<SignupTypeInput>();
            RegisterType<LoginTypeInput>();
        }
        public EmployeePlatformSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<EmployeePlatformQuery>();
            Mutation = resolver.Resolve<EmployeePlatformMutation>();
        }
    }
}
