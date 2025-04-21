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
            CreateMap<Employee,EmployeeDto>().ForMember(D => D.Department, opt => opt.MapFrom(scr => scr.Department != null ? scr.Department.Name : null));

            CreateMap<Employee, EmployeeAllDetailsDTO>()
                .ForMember(D => D.HiringDate, opt => opt.MapFrom(scr => DateOnly.FromDateTime(scr.HiringDate)))
                .ForMember(D => D.Department, opt => opt.MapFrom(scr => scr.Department != null ? scr.Department.Name : null))
                .ForMember(D => D.ProfileImageName, opt => opt.MapFrom(scr => scr.ImageName));

            CreateMap<CreatedEmployeeDTO, Employee>()
                .ForMember(D => D.HiringDate, opt => opt.MapFrom(scr => scr.HiringDate.ToDateTime(TimeOnly.MinValue)));

            CreateMap<UpdatedEmployeeDTO, Employee>();
        }
    }
}
