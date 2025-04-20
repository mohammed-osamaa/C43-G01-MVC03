using Demo.BusinessLogicLayer.DTOS.UserDTOS;
using Demo.DataAccessLayer.Models.IdentityModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Services.UserServices
{
    public interface IUserServices
    {
        IEnumerable<UserDto> GetAllUsers(string? Search);
        UserAllDetailsDto? GetUserById(string id);
        bool UpdateUser(UpdatedUserDto user);
        bool DeleteUser(string id);
    }
}
