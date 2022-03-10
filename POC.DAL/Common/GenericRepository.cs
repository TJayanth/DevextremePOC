using Dapper;
using POC.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.DAL.Common
{
    /// <summary>
    /// Represents the Generic repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>
       where TEntity : class
    {
        #region Private Variables
        private string _connectionString;
        private EDbConnectionTypes _dbType;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for Generic Repository
        /// </summary>
        /// <param name="connectionString"></param>
        public GenericRepository(string connectionString)
        {
            _dbType = EDbConnectionTypes.Sql;
            _connectionString = connectionString;
        }
        #endregion

        #region Connection
        /// <summary>
        /// Open Connection
        /// </summary>
        /// <returns></returns>
        public IDbConnection GetOpenConnection()
        {
            return DBConnectionFactory.GetDbConnection(_dbType, _connectionString);
        }
        #endregion

        #region Delete Method
        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="sql">SQL Stored Procedure</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>Entity</returns>
        public virtual async Task<IResultDTO<bool>> DeleteAsync(string sql, DynamicParameters parameters)
        {
            return await DeleteAsync<TEntity>(sql, parameters);
        }

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="sql">SQL Stored Procedure</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>Entity</returns>
        public virtual async Task<IResultDTO<bool>> DeleteAsync<TGenericEntity>(string sql, DynamicParameters parameters)
        {
            var _result = new ResultDTO<bool>
            {
                Errors = new List<string>(),
                IsSuccess = false,
                Message = string.Empty
            };
            try
            {
                parameters = AddOutputParameters(parameters);
                using (var conn = GetOpenConnection())
                {
                    _result.Data = await conn.QueryFirstOrDefaultAsync<bool>(sql, parameters, commandType: CommandType.StoredProcedure);
                    _result.Data = parameters.Get<bool>("Status");
                    _result.IsSuccess = parameters.Get<bool>("Status");
                    _result.Message = parameters.Get<string>("Message");
                }
            }
            catch (SqlException sqex)
            {
                _result.Errors.Add(sqex.Message);
                _result.Message = string.Empty;
            }
            catch (DbException dbex)
            {
                _result.Errors.Add(dbex.Message);
                _result.Message = string.Empty;
            }
            catch (Exception ex)
            {
                _result.Errors.Add(ex.Message);
                _result.Message = string.Empty;
            }

            return _result;
        }
        #endregion

        #region Get Method
        /// <summary>
        /// Get All Entities
        /// </summary>
        /// <param name="sql">SQL Stored Procedure</param>
        /// <returns>Entities</returns>
        public virtual async Task<IResultDTO<IEnumerable<TEntity>>> GetAllAsync(string sql)
        {
            return await GetAllAsync<TEntity>(sql);
        }

        public virtual IResultDTO<IEnumerable<TEntity>> GetAll(string sql)
        {
            return GetAll<TEntity>(sql);
        }

        public virtual IResultDTO<IEnumerable<TEntity>> GetAll(string sql, DynamicParameters parameters)
        {
            return GetAll<TEntity>(sql, parameters);
        }

        /// <summary>
        /// Get All Entities
        /// </summary>
        /// <param name="sql">SQL Stored Procedure</param>
        /// <returns>Entities</returns>
        public virtual async Task<IResultDTO<IEnumerable<TGenericEntity>>> GetAllAsync<TGenericEntity>(string sql)
        {
            var _result = new ResultDTO<IEnumerable<TGenericEntity>>()
            {
                Errors = new List<string>(),
                IsSuccess = false,
                Message = string.Empty
            };
            try
            {
                DynamicParameters parameters = AddOutputParameters(new DynamicParameters());
                using (var conn = GetOpenConnection())
                {
                    _result.Data = await conn.QueryAsync<TGenericEntity>(sql, parameters, commandType: CommandType.StoredProcedure);
                    _result.IsSuccess = true;
                    _result.Message = "Successfully fetched data";
                }
            }
            catch (SqlException sqex)
            {
                _result.Errors.Add(sqex.Message);
                _result.Message = string.Empty;
            }
            catch (DbException dbex)
            {
                _result.Errors.Add(dbex.Message);
                _result.Message = string.Empty;
            }
            catch (Exception ex)
            {
                _result.Errors.Add(ex.Message);
                _result.Message = string.Empty;
            }

            return _result;
        }

        public virtual IResultDTO<IEnumerable<TGenericEntity>> GetAll<TGenericEntity>(string sql)
        {
            var _result = new ResultDTO<IEnumerable<TGenericEntity>>()
            {
                Errors = new List<string>(),
                IsSuccess = false,
                Message = string.Empty
            };
            try
            {
                DynamicParameters parameters = AddOutputParameters(new DynamicParameters());
                using (var conn = GetOpenConnection())
                {
                    _result.Data = conn.Query<TGenericEntity>(sql, parameters, commandType: CommandType.StoredProcedure);
                    _result.IsSuccess = true;
                    _result.Message = "Successfully fetched data";
                }
            }
            catch (SqlException sqex)
            {
                _result.Errors.Add(sqex.Message);
                _result.Message = string.Empty;
            }
            catch (DbException dbex)
            {
                _result.Errors.Add(dbex.Message);
                _result.Message = string.Empty;
            }
            catch (Exception ex)
            {
                _result.Errors.Add(ex.Message);
                _result.Message = string.Empty;
            }

            return _result;
        }

        public virtual IResultDTO<IEnumerable<TGenericEntity>> GetAll<TGenericEntity>(string sql, DynamicParameters parameters)
        {
            var _result = new ResultDTO<IEnumerable<TGenericEntity>>()
            {
                Errors = new List<string>(),
                IsSuccess = false,
                Message = string.Empty
            };
            try
            {
                parameters = AddOutputParameters(parameters);
                using (var conn = GetOpenConnection())
                {
                    _result.Data = conn.Query<TGenericEntity>(sql, parameters, commandType: CommandType.StoredProcedure);
                    _result.IsSuccess = true;
                    _result.Message = "Successfully fetched data";
                }
            }
            catch (SqlException sqex)
            {
                _result.Errors.Add(sqex.Message);
                _result.Message = string.Empty;
            }
            catch (DbException dbex)
            {
                _result.Errors.Add(dbex.Message);
                _result.Message = string.Empty;
            }
            catch (Exception ex)
            {
                _result.Errors.Add(ex.Message);
                _result.Message = string.Empty;
            }

            return _result;
        }

        /// <summary>
        /// Get All Entities
        /// </summary>
        /// <param name="sql">SQL Stored Procedure</param>
        /// <param name="parameters">Parametes</param>
        /// <returns>Entities</returns>
        public virtual async Task<IResultDTO<IEnumerable<TEntity>>> GetAllAsync(string sql, DynamicParameters parameters)
        {
            return await GetAllAsync<TEntity>(sql, parameters);
        }

        /// <summary>
        /// Get All Entities
        /// </summary>
        /// <param name="sql">SQL Stored Procedure</param>
        /// <param name="parameters">Parametes</param>
        /// <returns>Entities</returns>
        public virtual async Task<IResultDTO<IEnumerable<TGenericEntity>>> GetAllAsync<TGenericEntity>(string sql, DynamicParameters parameters)
        {
            var _result = new ResultDTO<IEnumerable<TGenericEntity>>()
            {
                Errors = new List<string>(),
                IsSuccess = false,
                Message = string.Empty
            };
            try
            {
                parameters = AddOutputParameters(parameters);
                using (var conn = GetOpenConnection())
                {
                    _result.Data = await conn.QueryAsync<TGenericEntity>(sql, parameters, commandType: CommandType.StoredProcedure);
                    _result.IsSuccess = parameters.Get<bool>("Status");
                    _result.Message = parameters.Get<string>("Message");
                }
            }
            catch (SqlException sqex)
            {
                _result.Errors.Add(sqex.Message);
                _result.Message = string.Empty;
            }
            catch (DbException dbex)
            {
                _result.Errors.Add(dbex.Message);
                _result.Message = string.Empty;
            }
            catch (Exception ex)
            {
                _result.Errors.Add(ex.Message);
                _result.Message = string.Empty;
            }

            return _result;
        }

        /// <summary>
        /// CheckIfExists
        /// </summary>
        /// <param name="sql">SQL Stored Procedure</param>
        /// <param name="parameters">Parametes</param>
        /// <returns>Entities</returns>
        public virtual async Task<IResultDTO<bool>> CheckIfExists(string sql, DynamicParameters parameters)
        {
            var _result = new ResultDTO<bool>()
            {
                Errors = new List<string>(),
                IsSuccess = false,
                Message = string.Empty
            };
            try
            {
                parameters = AddOutputParameters(parameters);
                using (var conn = GetOpenConnection())
                {
                    _result.Data = await conn.QueryFirstOrDefaultAsync<bool>(sql, parameters, commandType: CommandType.StoredProcedure);
                    _result.Data = parameters.Get<bool>("Status");
                    _result.IsSuccess = parameters.Get<bool>("Status");
                    _result.Message = parameters.Get<string>("Message");
                }
            }
            catch (SqlException sqex)
            {
                _result.Errors.Add(sqex.Message);
                _result.Message = string.Empty;
            }
            catch (DbException dbex)
            {
                _result.Errors.Add(dbex.Message);
                _result.Message = string.Empty;
            }
            catch (Exception ex)
            {
                _result.Errors.Add(ex.Message);
                _result.Message = string.Empty;
            }

            return _result;
        }

        /// <summary>
        /// Get Single Entity
        /// </summary>
        /// <param name="sql">SQL Stored Procedure</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>Entity</returns>
        public virtual async Task<IResultDTO<TEntity>> GetSingleAsync(string sql, DynamicParameters parameters)
        {
            return await GetSingleAsync<TEntity>(sql, parameters);
        }

        /// <summary>
        /// Get Single Entity
        /// </summary>
        /// <param name="sql">SQL Stored Procedure</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>Entity</returns>
        public virtual async Task<IResultDTO<TGenericEntity>> GetSingleAsync<TGenericEntity>(string sql, DynamicParameters parameters)
        {
            var _result = new ResultDTO<TGenericEntity>()
            {
                Errors = new List<string>(),
                IsSuccess = false,
                Message = string.Empty
            };
            try
            {
                parameters = AddOutputParameters(parameters);
                using (var conn = GetOpenConnection())
                {
                    _result.Data = await conn.QueryFirstOrDefaultAsync<TGenericEntity>(sql, parameters, commandType: CommandType.StoredProcedure);
                    _result.IsSuccess = parameters.Get<bool>("Status");
                    _result.Message = parameters.Get<string>("Message");
                }
            }
            catch (SqlException sqex)
            {
                _result.Errors.Add(sqex.Message);
                _result.Message = string.Empty;
            }
            catch (DbException dbex)
            {
                _result.Errors.Add(dbex.Message);
                _result.Message = string.Empty;
            }
            catch (Exception ex)
            {
                _result.Errors.Add(ex.Message);
                _result.Message = string.Empty;
            }

            return _result;
        }

        public virtual IResultDTO<TGenericEntity> GetSingle<TGenericEntity>(string sql, DynamicParameters parameters)
        {
            var _result = new ResultDTO<TGenericEntity>()
            {
                Errors = new List<string>(),
                IsSuccess = false,
                Message = string.Empty
            };
            try
            {
                parameters = AddOutputParameters(parameters);
                using (var conn = GetOpenConnection())
                {
                    _result.Data = conn.QueryFirstOrDefault<TGenericEntity>(sql, parameters, commandType: CommandType.StoredProcedure);
                    _result.IsSuccess = parameters.Get<bool>("Status");
                    _result.Message = parameters.Get<string>("Message");
                }
            }
            catch (SqlException sqex)
            {
                _result.Errors.Add(sqex.Message);
                _result.Message = string.Empty;
            }
            catch (DbException dbex)
            {
                _result.Errors.Add(dbex.Message);
                _result.Message = string.Empty;
            }
            catch (Exception ex)
            {
                _result.Errors.Add(ex.Message);
                _result.Message = string.Empty;
            }

            return _result;
        }

        /// <summary>
        /// Get Single Entity
        /// </summary>
        /// <param name="sql">SQL Stored Procedure</param>
        /// <returns>Entity</returns>
        public virtual async Task<IResultDTO<TEntity>> GetSingleAsync(string sql)
        {
            return await GetSingleAsync<TEntity>(sql);
        }

        /// <summary>
        /// Get Single Entity
        /// </summary>
        /// <param name="sql">SQL Stored Procedure</param>
        /// <returns>Entity</returns>
        public virtual async Task<IResultDTO<TGenericEntity>> GetSingleAsync<TGenericEntity>(string sql)
        {
            var _result = new ResultDTO<TGenericEntity>()
            {
                Errors = new List<string>(),
                IsSuccess = false,
                Message = string.Empty
            };
            var parameters = new DynamicParameters();
            try
            {
                parameters = AddOutputParameters(parameters);
                using (var conn = GetOpenConnection())
                {
                    _result.Data = await conn.QueryFirstOrDefaultAsync<TGenericEntity>(sql, parameters, commandType: CommandType.StoredProcedure);
                    _result.IsSuccess = parameters.Get<bool>("Status");
                    _result.Message = parameters.Get<string>("Message");
                }
            }
            catch (SqlException sqex)
            {
                _result.Errors.Add(sqex.Message);
                _result.Message = string.Empty;
            }
            catch (DbException dbex)
            {
                _result.Errors.Add(dbex.Message);
                _result.Message = string.Empty;
            }
            catch (Exception ex)
            {
                _result.Errors.Add(ex.Message);
                _result.Message = string.Empty;
            }

            return _result;
        }

        /// <summary>
        /// Get All Entities
        /// </summary>
        /// <param name="sql">SQL Query</param>
        /// <returns>Entities</returns>
        public virtual async Task<IResultDTO<IEnumerable<TEntity>>> GetAllAsyncByQuery(string sql)
        {
            return await GetAllAsyncByQuery<TEntity>(sql);
        }

        /// <summary>
        /// Get All Entities
        /// </summary>
        /// <param name="sql">SQL Query</param>
        /// <returns>Entities</returns>
        public virtual async Task<IResultDTO<IEnumerable<TGenericEntity>>> GetAllAsyncByQuery<TGenericEntity>(string sql)
        {
            var _result = new ResultDTO<IEnumerable<TGenericEntity>>
            {
                Errors = new List<string>(),
                IsSuccess = false,
                Message = string.Empty
            };
            try
            {
                using (var conn = GetOpenConnection())
                {
                    _result.Data = await conn.QueryAsync<TGenericEntity>(sql, null, commandType: CommandType.Text);
                    _result.IsSuccess = true;
                    _result.Message = "Successfully fetched data";
                }
            }
            catch (SqlException sqex)
            {
                _result.Errors.Add(sqex.Message);
                _result.Message = string.Empty;
            }
            catch (DbException dbex)
            {
                _result.Errors.Add(dbex.Message);
                _result.Message = string.Empty;
            }
            catch (Exception ex)
            {
                _result.Errors.Add(ex.Message);
                _result.Message = string.Empty;
            }

            return _result;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="sql">SQL Stored Procedure</param>
        /// <returns>Entity</returns>
        public virtual async Task<IResultDTO<TEntity>> InsertAsync(TEntity entity, string sql)
        {
            return await InsertAsync<TEntity>(entity, sql);
        }

        /// <summary>
        /// Insert Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="sql">SQL Stored Procedure</param>
        /// <returns>Entity</returns>
        public virtual async Task<IResultDTO<TGenericEntity>> InsertAsync<TGenericEntity>(TGenericEntity entity, string sql)
        {
            var _result = new ResultDTO<TGenericEntity>
            {
                Errors = new List<string>(),
                IsSuccess = false,
                Message = string.Empty
            };
            var parameters = new DynamicParameters();
            try
            {
                parameters = AddOutputParameters(parameters);
                foreach (var prop in entity.GetType().GetProperties())
                {
                    if (prop.Name.ToLower() != "id" && prop.Name.ToLower() != "modifiedby" && prop.Name.ToLower() != "modifieddatetime")
                    {
                        if (prop.GetValue(entity, null) != null)
                        {
                            parameters.Add("@" + prop.Name, prop.GetValue(entity, null));
                        }
                    }
                }

                using (var conn = GetOpenConnection())
                {
                    _result.Data = await conn.QueryFirstOrDefaultAsync<TGenericEntity>(sql, parameters, commandType: CommandType.StoredProcedure);
                    _result.IsSuccess = parameters.Get<bool>("Status");
                    _result.Message = parameters.Get<string>("Message");
                }
            }
            catch (SqlException sqex)
            {
                _result.Errors.Add(sqex.Message);
                _result.Message = string.Empty;
            }
            catch (DbException dbex)
            {
                _result.Errors.Add(dbex.Message);
                _result.Message = string.Empty;
            }
            catch (Exception ex)
            {
                _result.Errors.Add(ex.Message);
                _result.Message = string.Empty;
            }

            return _result;
        }

        /// <summary>
        /// Insert Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="sql">SQL Stored Procedure</param>
        /// <returns>Entity</returns>
        public virtual async Task<IResultDTO<TEntity>> InsertAsync(string sql, DynamicParameters parameters)
        {
            return await InsertAsync<TEntity>(sql, parameters);
        }

        /// <summary>
        /// Insert Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="sql">SQL Stored Procedure</param>
        /// <returns>Entity</returns>
        public virtual async Task<IResultDTO<TGenericEntity>> InsertAsync<TGenericEntity>(string sql, DynamicParameters parameters)
        {
            var _result = new ResultDTO<TGenericEntity>
            {
                Errors = new List<string>(),
                IsSuccess = false,
                Message = string.Empty
            };
            try
            {
                parameters = AddOutputParameters(parameters);
                using (var conn = GetOpenConnection())
                {
                    _result.Data = await conn.QueryFirstOrDefaultAsync<TGenericEntity>(sql, parameters, commandType: CommandType.StoredProcedure);
                    _result.IsSuccess = parameters.Get<bool>("Status");
                    _result.Message = parameters.Get<string>("Message");
                }
            }
            catch (SqlException sqex)
            {
                _result.Errors.Add(sqex.Message);
                _result.Message = string.Empty;
            }
            catch (DbException dbex)
            {
                _result.Errors.Add(dbex.Message);
                _result.Message = string.Empty;
            }
            catch (Exception ex)
            {
                _result.Errors.Add(ex.Message);
                _result.Message = string.Empty;
            }

            return _result;
        }
        #endregion

        #region Update Method
        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="sql">SQL Stored Procedure</param>
        /// <returns>Entity</returns>
        public virtual async Task<IResultDTO<TEntity>> UpdateAsync(TEntity entity, string sql)
        {
            return await UpdateAsync<TEntity>(entity, sql);
        }

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="sql">SQL Stored Procedure</param>
        /// <returns>Entity</returns>
        public virtual async Task<IResultDTO<TGenericEntity>> UpdateAsync<TGenericEntity>(TGenericEntity entity, string sql)
        {
            var _result = new ResultDTO<TGenericEntity>()
            {
                Errors = new List<string>(),
                IsSuccess = false,
                Message = string.Empty
            };
            var parameters = new DynamicParameters();
            try
            {
                parameters = AddOutputParameters(parameters);
                foreach (var prop in entity.GetType().GetProperties())
                {
                    if (prop.Name.ToLower() != "createdby" && prop.Name.ToLower() != "createddatetime")
                    {
                        if (prop.GetValue(entity, null) != null)
                        {
                            parameters.Add("@" + prop.Name, prop.GetValue(entity, null));
                        }
                    }
                }

                using (var conn = GetOpenConnection())
                {
                    _result.Data = await conn.QueryFirstOrDefaultAsync<TGenericEntity>(sql, parameters, commandType: CommandType.StoredProcedure);
                    _result.IsSuccess = parameters.Get<bool>("Status");
                    _result.Message = parameters.Get<string>("Message");
                }
            }
            catch (SqlException sqex)
            {
                _result.Errors.Add(sqex.Message);
                _result.Message = string.Empty;
            }
            catch (DbException dbex)
            {
                _result.Errors.Add(dbex.Message);
                _result.Message = string.Empty;
            }
            catch (Exception ex)
            {
                _result.Errors.Add(ex.Message);
                _result.Message = string.Empty;
            }

            return _result;
        }

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="sql">SQL Stored Procedure</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>Entity</returns>
        public virtual async Task<IResultDTO<TEntity>> UpdateAsync(string sql, DynamicParameters parameters)
        {
            return await UpdateAsync<TEntity>(sql, parameters);
        }

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="sql">SQL Stored Procedure</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>Entity</returns>
        public virtual async Task<IResultDTO<TGenericEntity>> UpdateAsync<TGenericEntity>(string sql, DynamicParameters parameters)
        {
            var _result = new ResultDTO<TGenericEntity>
            {
                Errors = new List<string>(),
                IsSuccess = false,
                Message = string.Empty
            };
            try
            {
                parameters = AddOutputParameters(parameters);
                using (var conn = GetOpenConnection())
                {
                    _result.Data = await conn.QueryFirstOrDefaultAsync<TGenericEntity>(sql, parameters, commandType: CommandType.StoredProcedure);
                    _result.IsSuccess = parameters.Get<bool>("Status");
                    _result.Message = parameters.Get<string>("Message");
                }
            }
            catch (SqlException sqex)
            {
                _result.Errors.Add(sqex.Message);
                _result.Message = string.Empty;
            }
            catch (DbException dbex)
            {
                _result.Errors.Add(dbex.Message);
                _result.Message = string.Empty;
            }
            catch (Exception ex)
            {
                _result.Errors.Add(ex.Message);
                _result.Message = string.Empty;
            }

            return _result;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Bind Output Parameters
        /// </summary>
        /// <param name="parameters">Parameters</param>
        /// <returns>Dynamic Parameters</returns>
        private DynamicParameters AddOutputParameters(DynamicParameters parameters)
        {
            parameters.Add("@Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 8000);
            parameters.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
            return parameters;
        }
        #endregion

    }
}
