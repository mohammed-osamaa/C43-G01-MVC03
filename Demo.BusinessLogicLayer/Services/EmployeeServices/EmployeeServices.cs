using AutoMapper;
using Demo.BusinessLogicLayer.DTOS.EmployeeDTOs;
using Demo.BusinessLogicLayer.Factory;
using Demo.DataAccessLayer.Models.EmployeesModel;
using Demo.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Services.EmployeeServices
{
    public class EmployeeServices(IEmployeeRepository _employeeRepository, IMapper _mapper) : IEmployeeServices
    {
        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            //var Emps = _employeeRepository.GetAll(E => new EmployeeDto
            //{
            //    Id = E.Id,
            //    Name = E.Name,
            //    Age = E.Age,
            //    Salary = E.Salary,
            //    IsActive = E.IsActive,
            //    Gender = E.Gender,
            //    Email = E.Email,
            //    EmployeeType = E.EmployeeType
            //});
            //return Emps.Select(E => E.ToDTO()).ToList();
            var Emps = _employeeRepository.GetAll();
            var EmpsDTO = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(Emps);
            return EmpsDTO;
        }

        public EmployeeAllDetailsDTO? GetById(int id)
        {
            var emp = _employeeRepository.GetById(id);
            //return emp?.ToDetailsDTo();
            if (emp == null) return null;
            var EmpAllDetails = _mapper.Map<Employee,EmployeeAllDetailsDTO>(emp);
            return EmpAllDetails;
        }
        public bool CreateNewEmployee(CreatedEmployeeDTO dto)
        {
            //var Emp = dto.ToEntity();
            var Emp = _mapper.Map<CreatedEmployeeDTO , Employee>(dto);
            var res = _employeeRepository.add(Emp);
            return res > 0 ? true : false;
        }

        public bool UpdateExistedEmployee(UpdatedEmployeeDTO dto)
        {
            //var Emp = dto.ToEntity();
            var Emp = _mapper.Map<UpdatedEmployeeDTO, Employee>(dto);
            var res = _employeeRepository.Update(Emp);
            return res > 0 ? true : false;
        }
        public bool DeleteExistedEmployee(int id)
        {
            var emp = _employeeRepository.GetById(id);
            //// Hard Delete
            ///
            //if (emp != null)
            //{
            //    var res = employeeRepository.Delete(emp);
            //    return res > 0 ? true : false;
            //}
            //return false;

            ////Soft Delete
            if(emp == null) return false;
            emp.IsDeleted = true;
            return _employeeRepository.Update(emp) > 0 ? true : false ;
        }

    }
}
