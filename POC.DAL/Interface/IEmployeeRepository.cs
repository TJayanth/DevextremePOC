using POC.DAL.Common;
using POC.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.DAL.Interface
{
    public interface IEmployeeRepository : IGenericRepository<EmployeeDTO>
    {
    }
}
