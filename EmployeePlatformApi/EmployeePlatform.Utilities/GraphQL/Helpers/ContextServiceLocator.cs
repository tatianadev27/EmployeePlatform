using EmployeePlatform.DataAccess.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeePlatform.Utilities.GraphQL.Helpers
{
    public class ContextServiceLocator
    {
        public IAreaRepository AreaRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IAreaRepository>();
        public ISubareaRepository SubareaRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<ISubareaRepository>();
        public IIdentificationTypeRepository identificationTypeRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IIdentificationTypeRepository>();
        public IEmployeeRepository employeeRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IEmployeeRepository>();

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextServiceLocator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
