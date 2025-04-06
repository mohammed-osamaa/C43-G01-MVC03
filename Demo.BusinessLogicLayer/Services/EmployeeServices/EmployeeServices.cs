﻿using AutoMapper;
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
    public class EmployeeServices(IUnitOfWork _unitOfWork, IMapper _mapper) : IEmployeeServices
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(string? EmployeeSearchName)
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
            IEnumerable<Employee> Emps;
            if (string.IsNullOrEmpty(EmployeeSearchName))
                Emps = _unitOfWork.EmployeeRepository.GetAll();
            else
                Emps = _unitOfWork.EmployeeRepository.GetAll(E => E.Name.ToLower().Contains(EmployeeSearchName.ToLower()));
            var EmpsDTO = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(Emps);
            return EmpsDTO;
        }

        public EmployeeAllDetailsDTO? GetById(int id)
        {
            var emp = _unitOfWork.EmployeeRepository.GetById(id);
            //return emp?.ToDetailsDTo();
            if (emp == null) return null;
            var EmpAllDetails = _mapper.Map<Employee,EmployeeAllDetailsDTO>(emp);
            return EmpAllDetails;
        }
        public bool CreateNewEmployee(CreatedEmployeeDTO dto)
        {
            //var Emp = dto.ToEntity();
            var Emp = _mapper.Map<CreatedEmployeeDTO , Employee>(dto);
            _unitOfWork.EmployeeRepository.add(Emp);
            return _unitOfWork.SaveChanges() > 0 ? true : false;
        }

        public bool UpdateExistedEmployee(UpdatedEmployeeDTO dto)
        {
            //var Emp = dto.ToEntity();
            var Emp = _mapper.Map<UpdatedEmployeeDTO, Employee>(dto);
            _unitOfWork.EmployeeRepository.Update(Emp);
            return _unitOfWork.SaveChanges() > 0 ? true : false;
        }
        public bool DeleteExistedEmployee(int id)
        {
            var emp = _unitOfWork.EmployeeRepository.GetById(id);
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
            _unitOfWork.EmployeeRepository.Update(emp);
            return _unitOfWork.SaveChanges() > 0 ? true : false;
        }

    }
}
