using Demo.BusinessLogicLayer.DTOS.EmployeeDTOs;
using Demo.DataAccessLayer.Models.EmployeesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Factory
{
    public static class EmployeeFactory
    {
        public static EmployeeDto ToDTO(this Employee employee)
        {
            return new EmployeeDto()
            {
                Id = employee.Id,
                Name=employee.Name,
                Age=employee.Age,
                Salary=employee.Salary,
                Gender=employee.Gender,
                Email=employee.Email,
                EmployeeType=employee.EmployeeType,
                IsActive=employee.IsActive
            };
        }
        public static Employee ToEntity(this CreatedEmployeeDTO employee)
        {
            return new Employee()
            {
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
                Gender = employee.Gender,
                Email = employee.Email,
                EmployeeType = employee.EmployeeType,
                IsActive = employee.IsActive,
                Address = employee.Address,
                PhoneNumber = employee.PhoneNumber,
            };
        }
        public static Employee ToEntity(this UpdatedEmployeeDTO employee)
        {
            return new Employee()
            {
                Id=employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
                Gender = employee.Gender,
                Email = employee.Email,
                EmployeeType = employee.EmployeeType,
                IsActive = employee.IsActive,
                Address = employee.Address,
                PhoneNumber = employee.PhoneNumber,
                CreatedBy = employee.CreatedBy,
                LastModifiedBy = employee.LastModifiedBy,
            };
        }
        public static EmployeeAllDetailsDTO ToDetailsDTo(this Employee employee)
        {
            return new EmployeeAllDetailsDTO()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
                Gender = employee.Gender,
                Email = employee.Email,
                EmployeeType = employee.EmployeeType,
                IsActive = employee.IsActive,
                Address = employee.Address,
                HiringDate = employee.HiringDate,
                PhoneNumber = employee.PhoneNumber,
            };
        }
    }
}
