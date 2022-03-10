using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.DAL.Common
{
    class DBConnectionFactory
    {
        #region DB Connection
        /// <summary>
        /// GetDbConnection
        /// </summary>
        /// <param name="dbType"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IDbConnection GetDbConnection(EDbConnectionTypes dbType, string connectionString)
        {
            IDbConnection connection = null;

            switch (dbType)
            {
                case EDbConnectionTypes.Sql:
                    connection = new SqlConnection(connectionString);
                    break;
                default:
                    connection = new SqlConnection(connectionString);
                    break;
            }
            connection.Open();
            return connection;
        }
        #endregion
    }

    /// <summary>
    /// EDbConnectionTypes
    /// </summary>
    public enum EDbConnectionTypes
    {
        Sql,
    }
}
