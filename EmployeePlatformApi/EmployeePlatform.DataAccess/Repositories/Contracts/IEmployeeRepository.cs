using EmployeePlatform.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeePlatform.DataAccess.Repositories.Contracts
{
    /// <summary>
    /// Employer Interface
    /// </summary>
    public interface IEmployeeRepository : IBaseRepository<EmployeeDTO, int>
    {
        /// <summary>
        /// Employee List Paginate
        /// </summary>
        /// <param name="pageSize">Page zise</param>
        /// <param name="page">Page number</param>
        /// <param name="filter">Filter</param>
        /// <returns></returns>
        Task<IEnumerable<EmployeeDTO>> GetAll(int pageSize, int page, string filter);

        /// <summary>
        /// Employee List Paginate
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns></returns>
        Task<IEnumerable<EmployeeDTO>> GetAll(string filter);

    }
}
