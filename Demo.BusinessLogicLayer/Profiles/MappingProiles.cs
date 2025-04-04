using AutoMapper;
using Demo.BusinessLogicLayer.DTOS.EmployeeDTOs;
using Demo.DataAccessLayer.Models.EmployeesModel;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Profiles
{
    public class MappingProiles : Profile
    {
        public MappingProiles()
        {
            CreateMap<Employee,EmployeeDto>();
            CreateMap<Employee,EmployeeAllDetailsDTO>();
            CreateMap<CreatedEmployeeDTO, Employee>();
            CreateMap<UpdatedEmployeeDTO, Employee>();
        }
    }
}
