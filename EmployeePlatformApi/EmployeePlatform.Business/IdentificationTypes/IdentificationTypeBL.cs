using EmployeePlatform.DataAccess.Repositories.Contracts;
using EmployeePlatform.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeePlatform.Business
{
    public class IdentificationTypeBL : IIdentificationTypeRepository 
    {
        private IIdentificationTypeRepository _identificationTypeRepository;


        public IdentificationTypeBL(IIdentificationTypeRepository identificationTypeRepository)
        {
            _identificationTypeRepository = identificationTypeRepository;
        }

        public Task<IdentificationTypeDTO> Add(IdentificationTypeDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<IdentificationTypeDTO>> GetAll()
        {
            return await _identificationTypeRepository.GetAll();
        }

        public async Task<IdentificationTypeDTO> GetById(int Id)
        {
            return await _identificationTypeRepository.GetById(Id);
        }

        public Task<IdentificationTypeDTO> Update(IdentificationTypeDTO entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
