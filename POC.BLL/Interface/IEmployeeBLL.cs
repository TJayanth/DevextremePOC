using POC.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.BLL.Interface
{
    public interface IEmployeeBLL
    {
        Task<IResultDTO<IEnumerable<EmployeeDTO>>> GetEmployeeList();
    }
}
