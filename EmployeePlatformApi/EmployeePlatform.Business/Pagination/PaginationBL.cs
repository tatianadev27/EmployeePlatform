using EmployeePlatform.DataAccess.Repositories.Contracts;
using EmployeePlatform.Entities;
using System.Threading.Tasks;

namespace EmployeePlatform.Business
{
    public class PaginationBL : IPaginationRepository
    {
        private IPaginationRepository _paginationRepository;


        public PaginationBL(IPaginationRepository paginationRepository)
        {
            _paginationRepository = paginationRepository;
        }
        public async Task<PaginationDTO> GetPaginationData(int pageSize, string filter)
        {
            return await _paginationRepository.GetPaginationData(pageSize, filter);
        }
    }
}
