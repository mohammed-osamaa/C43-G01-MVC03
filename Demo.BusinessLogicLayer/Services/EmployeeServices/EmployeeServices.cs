using Demo.BusinessLogicLayer.DTOS.EmployeeDTOs;
using Demo.BusinessLogicLayer.Factory;
using Demo.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Services.EmployeeServices
{
    public class EmployeeServices(IEmployeeRepository employeeRepository) : IEmployeeServices
    {
        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            var Emps = employeeRepository.GetAll().ToList();
            return Emps.Select(E => E.ToDTO()).ToList();
        }

        public EmployeeAllDetailsDTO? GetById(int id)
        {
            var emp = employeeRepository.GetById(id);
            return emp?.ToDetailsDTo();
        }
        public bool CreateNewEmployee(CreatedEmployeeDTO dto)
        {
            var Emp = dto.ToEntity();
            var res = employeeRepository.add(Emp);
            return res > 0 ? true : false;
        }

        public bool UpdateExistedEmployee(UpdatedEmployeeDTO dto)
        {
            var Emp = dto.ToEntity();
            var res = employeeRepository.Update(Emp);
            return res > 0 ? true : false;
        }
        public bool DeleteExistedEmployee(int id)
        {
            var emp = employeeRepository.GetById(id);
            if (emp != null)
            {
                var res = employeeRepository.Delete(emp);
                return res > 0 ? true : false;
            }
            return false;
        }

    }
}
