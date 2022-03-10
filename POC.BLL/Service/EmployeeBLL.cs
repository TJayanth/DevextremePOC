using Dapper;
using POC.BLL.Interface;
using POC.DAL.Constants;
using POC.DAL.Repository;
using POC.DTO;
using POC.BLL.Interface;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using POC.DAL.Interface;

namespace POC.BLL.Service
{
    public class EmployeeBLL : IEmployeeBLL
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeBLL(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IResultDTO<IEnumerable<EmployeeDTO>>> GetEmployeeList()
        {
            var sql = StoredProcedure.Employees.GetEmployee;

            return new ResultDTO<IEnumerable<EmployeeDTO>>() {
                Data = new List<EmployeeDTO>()
            {
                new EmployeeDTO()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "jayanth",
                    FathersName = "T",
                    MothersName = "H",
                    IsActive = true
                },
                 new EmployeeDTO()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "John",
                    FathersName = "TR",
                    MothersName = "Hasd",
                    IsActive = false
                },
                   new EmployeeDTO()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Adam",
                    FathersName = "Teess",
                    MothersName = "Sparow",
                    IsActive = true
                },
            }
            };
            //return await _employeeRepository.GetAllAsync<EmployeeDTO>(sql);
        }
    }
}
