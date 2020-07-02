using EmployeePlatform.DataAccess.Repositories.Contracts;
using EmployeePlatform.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeePlatform.Business
{
    public class AreaBL : IAreaRepository
    {
        private IAreaRepository _areaRepository;

        public AreaBL(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public Task<AreaDTO> Add(AreaDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<AreaDTO>> GetAll()
        {
            return await _areaRepository.GetAll();
        }

        public async Task<AreaDTO> GetById(int Id)
        {
            return await _areaRepository.GetById(Id);
        }

        public Task<AreaDTO> Update(AreaDTO entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
