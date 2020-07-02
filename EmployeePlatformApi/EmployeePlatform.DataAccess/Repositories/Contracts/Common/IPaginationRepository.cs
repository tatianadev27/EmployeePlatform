using EmployeePlatform.Entities;
using System.Threading.Tasks;

namespace EmployeePlatform.DataAccess.Repositories.Contracts
{
    /// <summary>
    /// Inteface base
    /// </summary>
    /// <typeparam name="TKey">Key Type e.g. Int</typeparam>
    public interface IPaginationRepository
    {
        public Task<PaginationDTO> GetPaginationData(int pageSize, string filter);
    }
}