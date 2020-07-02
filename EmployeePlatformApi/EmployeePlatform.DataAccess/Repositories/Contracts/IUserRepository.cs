using EmployeePlatform.Entities;
using System.Threading.Tasks;

namespace EmployeePlatform.DataAccess.Repositories.Contracts
{
    /// <summary>
    /// User Interface
    /// </summary>
    public interface IUserRepository : IBaseRepository<UserDTO, int>
    {
        /// <summary>
        /// Get data
        /// </summary>
        /// <param name="email">Identification</param>
        /// <returns></returns>
        Task<UserDTO> GetByEmail(string email);
    }
}
