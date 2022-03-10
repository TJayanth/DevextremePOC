using Dapper;
using POC.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.DAL.Common
{
    /// <summary>
    /// IGenericRepository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericRepository<TEntity>
    {
        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        Task<IResultDTO<IEnumerable<TEntity>>> GetAllAsync(string sql);

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        Task<IResultDTO<IEnumerable<TGenericEntity>>> GetAllAsync<TGenericEntity>(string sql);

        /// <summary>
        /// Get All with parameters
        /// </summary>
        /// <returns></returns>
        Task<IResultDTO<IEnumerable<TEntity>>> GetAllAsync(string sql, DynamicParameters parameters);

        /// <summary>
        /// Get All with parameters
        /// </summary>
        /// <returns></returns>
        Task<IResultDTO<IEnumerable<TGenericEntity>>> GetAllAsync<TGenericEntity>(string sql, DynamicParameters parameters);

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<IResultDTO<TEntity>> GetSingleAsync(string sql, DynamicParameters parameters);

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<IResultDTO<TGenericEntity>> GetSingleAsync<TGenericEntity>(string sql, DynamicParameters parameters);

        /// <summary>
        /// Get 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        Task<IResultDTO<TEntity>> GetSingleAsync(string sql);

        /// <summary>
        /// Get 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        Task<IResultDTO<TGenericEntity>> GetSingleAsync<TGenericEntity>(string sql);

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="entity"></param>
        Task<IResultDTO<TEntity>> InsertAsync(TEntity entity, string sql);

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="entity"></param>
        Task<IResultDTO<TGenericEntity>> InsertAsync<TGenericEntity>(TGenericEntity entity, string sql);

        /// <summary>
        /// Insert with parameters
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<IResultDTO<TEntity>> InsertAsync(string sql, DynamicParameters parameters);

        /// <summary>
        /// Insert with parameters
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        Task<IResultDTO<TGenericEntity>> InsertAsync<TGenericEntity>(string sql, DynamicParameters parameters);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        Task<IResultDTO<bool>> DeleteAsync(string sql, DynamicParameters parameters);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        Task<IResultDTO<bool>> DeleteAsync<TGenericEntity>(string sql, DynamicParameters parameters);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entityToUpdate"></param>
        Task<IResultDTO<TEntity>> UpdateAsync(TEntity entity, string sql);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entityToUpdate"></param>
        Task<IResultDTO<TGenericEntity>> UpdateAsync<TGenericEntity>(TGenericEntity entity, string sql);

        /// <summary>
        /// update with parameters
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<IResultDTO<TEntity>> UpdateAsync(string sql, DynamicParameters parameters);

        /// <summary>
        /// update with parameters
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<IResultDTO<TGenericEntity>> UpdateAsync<TGenericEntity>(string sql, DynamicParameters parameters);

        /// <summary>
        /// Get All By Query
        /// </summary>
        /// <returns></returns>
        Task<IResultDTO<IEnumerable<TEntity>>> GetAllAsyncByQuery(string sql);

        /// <summary>
        /// Get All By Query
        /// </summary>
        /// <returns></returns>
        Task<IResultDTO<IEnumerable<TGenericEntity>>> GetAllAsyncByQuery<TGenericEntity>(string sql);

        /// <summary>
        /// CheckIfExists
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<IResultDTO<bool>> CheckIfExists(string sql, DynamicParameters parameters);
    }
}
