using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeePlatform.DataAccess.Repositories.Contracts
{
    /// <summary>
    /// Inteface base
    /// </summary>
    /// <typeparam name="TEntity">Entity Type e.g. Area</typeparam>
    /// <typeparam name="TKey">Key Type e.g. Int</typeparam>
    public interface IBaseRepository<TEntity, in TKey>
        where TEntity : class
    {
        /// <summary>
        /// Get list data
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// Get data
        /// </summary>
        /// <param name="id">Identification</param>
        /// <returns></returns>
        Task<TEntity> GetById(TKey id);


        /// <summary>
        /// Add data
        /// </summary>
        /// <param name="entity">entity</param>
        /// <returns></returns>
        Task<TEntity> Add(TEntity entity);

        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="entity">entity</param>
        /// <returns></returns>
        Task<TEntity> Update(TEntity entity);


        /// <summary>
        /// Delele data
        /// </summary>
        /// <param name="id">Identification</param>
        /// <returns></returns>
        Task<bool> Delete(TKey id);

    }
}