using POC.DAL.Common;
using POC.DAL.Interface;
using POC.DTO;

namespace POC.DAL.Repository
{
    public class EmployeeRepository : GenericRepository<EmployeeDTO>, IEmployeeRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor for UserRepository
        /// </summary>
        /// <param name="connectionString"></param>
        public EmployeeRepository(string connectionString)
          : base(connectionString)
        {
        }
        #endregion
    }
}
