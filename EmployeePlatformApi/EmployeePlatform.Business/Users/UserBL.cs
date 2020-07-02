using EmployeePlatform.DataAccess.Repositories.Contracts;
using EmployeePlatform.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeePlatform.Business
{
    public class UserBL : IUserRepository
    {
        private IUserRepository _userRepository;


        public UserBL(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Add(UserDTO entity)
        {
            return await _userRepository.Add(entity);
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<UserDTO> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }


        public async Task<UserDTO> GetByEmail(string email)
        {
            return await _userRepository.GetByEmail(email);
        }

        public Task<UserDTO> Update(UserDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
