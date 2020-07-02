using EmployeePlatform.DataAccess.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeePlatform.GraphQLServer.Helpers
{
    public class ContextServiceLocator
    {
        public IAreaRepository AreaRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IAreaRepository>();
        public ISubareaRepository SubareaRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<ISubareaRepository>();
        public IIdentificationTypeRepository identificationTypeRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IIdentificationTypeRepository>();
        public IEmployeeRepository employeeRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IEmployeeRepository>();
        public IUserRepository userRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IUserRepository>();
        public IPaginationRepository paginationRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IPaginationRepository>();

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextServiceLocator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
