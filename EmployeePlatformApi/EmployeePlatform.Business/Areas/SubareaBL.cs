using EmployeePlatform.DataAccess.Repositories.Contracts;
using EmployeePlatform.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeePlatform.Business
{
    public class SubareaBL : ISubareaRepository
    {
        private ISubareaRepository _subareaRepository;

        public SubareaBL(ISubareaRepository subareaRepository)
        {
            _subareaRepository = subareaRepository;
        }

        public Task<SubareaDTO> Add(SubareaDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<SubareaDTO>> GetAll()
        {
            return await _subareaRepository.GetAll();
        }

        public async Task<IEnumerable<SubareaDTO>> GetAllForArea(int areaId)
        {
            return await _subareaRepository.GetAllForArea(areaId);
        }

        public async Task<SubareaDTO> GetById(int id)
        {
            return await _subareaRepository.GetById(id);
        }

        public Task<SubareaDTO> Update(SubareaDTO entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
