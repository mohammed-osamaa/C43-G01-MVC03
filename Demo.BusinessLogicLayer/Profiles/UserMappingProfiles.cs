using AutoMapper;
using Demo.BusinessLogicLayer.DTOS.UserDTOS;
using Demo.DataAccessLayer.Models.IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Profiles
{
    public class UserMappingProfiles : Profile
    {
        public UserMappingProfiles()
        {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<UpdatedUserDto, ApplicationUser>();
            CreateMap<ApplicationUser, UserAllDetailsDto>().ReverseMap();
        }
    }
}
