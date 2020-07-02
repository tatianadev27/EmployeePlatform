using EmployeePlatform.DataAccess.Repositories.Contracts;
using EmployeePlatform.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeePlatform.Business
{
    public class EmployeeBL : IEmployeeRepository
    {
        private IEmployeeRepository _employeeRepository;


        public EmployeeBL(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAll(int pageSize, int page, string filter)
        {
            return await _employeeRepository.GetAll(pageSize, page, filter);
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAll(string filter)
        {
            return await _employeeRepository.GetAll(filter);
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            return await _employeeRepository.GetAll();
        }

        public async Task<EmployeeDTO> GetById(int id)
        {
            return await _employeeRepository.GetById(id);
        }

        public async Task<EmployeeDTO> Add(EmployeeDTO entity)
        {
            return await _employeeRepository.Add(entity);
        }

        public async Task<EmployeeDTO> Update(EmployeeDTO entity)
        {
            return await _employeeRepository.Update(entity);
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
