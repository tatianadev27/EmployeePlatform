using Microsoft.EntityFrameworkCore;

namespace EmployeePlatform.Database
{
    public class EmployeePlatformContextFactory : DesignTimeDbContextFactoryBase<EmployeePlatformContext>
    {
        protected override EmployeePlatformContext CreateNewInstance(DbContextOptions<EmployeePlatformContext> options)
        {
            return new EmployeePlatformContext(options);
        }
    }
}
