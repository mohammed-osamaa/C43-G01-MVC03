using Demo.BusinessLogicLayer.DTOS.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Services.EmployeeServices
{
    public interface IEmployeeServices
    {
        bool CreateNewEmployee(CreatedEmployeeDTO dto);
        bool DeleteExistedEmployee(int id);
        IEnumerable<EmployeeDto> GetAllEmployees(string? EmployeeSearchName);
        EmployeeAllDetailsDTO? GetById(int id);
        bool UpdateExistedEmployee(UpdatedEmployeeDTO dto);
    }
}
