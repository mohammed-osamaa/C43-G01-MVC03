﻿using AutoMapper;
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

            CreateMap<Employee,EmployeeAllDetailsDTO>()
                .ForMember(D => D.HiringDate, opt => opt.MapFrom(scr => DateOnly.FromDateTime(scr.HiringDate)));

            CreateMap<CreatedEmployeeDTO, Employee>()
                .ForMember(D => D.HiringDate, opt => opt.MapFrom(scr => scr.HiringDate.ToDateTime(TimeOnly.MinValue)));

            CreateMap<UpdatedEmployeeDTO, Employee>();
        }
    }
}
