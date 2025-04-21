using AutoMapper;
using Demo.BusinessLogicLayer.DTOS.RoleDTOS;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Profiles
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<IdentityRole, RoleDto>().ReverseMap();
            CreateMap<CreatedRole, IdentityRole>();
        }
    }
}
