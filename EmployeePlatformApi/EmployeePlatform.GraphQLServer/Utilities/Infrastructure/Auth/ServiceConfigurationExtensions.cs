using EmployeePlatform.GraphQLServer.Common;
using GraphQL.Authorization;
using GraphQL.Validation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Security.Claims;


namespace EmployeePlatform.GraphQLServer.Infrastructure.Auth
{
    public static class ServiceConfigurationExtensions
    {
        public static void AddGraphQLAuth(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationEvaluator, AuthorizationEvaluator>();
            services.AddTransient<IValidationRule, AuthorizationValidationRule>();
            services.TryAddSingleton(s =>
            {
                var authSettings = new AuthorizationSettings();

                authSettings.AddPolicy(Policies.Employer, _ => _.RequireClaim(ClaimTypes.Role, "employer"));
                authSettings.AddPolicy(Policies.Admin, _ => _.RequireClaim(ClaimTypes.Role, "admin"));

                return authSettings;
            });
        }
    }
}