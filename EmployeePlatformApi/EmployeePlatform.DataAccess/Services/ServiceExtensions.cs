using EmployeePlatform.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace EmployeePlatform.DataAccess
{
    public static class ServiceExtensions
    {
        public static void AddContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EmployeePlatformContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
