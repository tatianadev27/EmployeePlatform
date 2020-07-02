using EmployeePlatform.Database.Models;
using EmployeePlatform.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeePlatform.DataAccess.Repositories.Contracts
{
    /// <summary>
    /// Subareas Interface
    /// </summary>
    public interface ISubareaRepository: IBaseRepository<SubareaDTO, int>
    {
        /// <summary>
        /// Subareas List 
        /// </summary>
        /// <param name="areaId">Identification in area entity</param>
        /// <returns></returns>
        Task<IEnumerable<SubareaDTO>> GetAllForArea(int areaId);
    }
}
