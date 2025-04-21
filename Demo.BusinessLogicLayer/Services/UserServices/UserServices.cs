using AutoMapper;
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
    public class UserServices(UserManager<ApplicationUser> _userManager , IMapper _mapper) : IUserServices
    {
        public IEnumerable<UserDto> GetAllUsers(string? Search)
        {
            IEnumerable<ApplicationUser> users;
            if (string.IsNullOrEmpty(Search))
                users = _userManager.Users.ToList();
            else
                users= _userManager.Users.Where(u=>u.FirstName.ToLower().Contains(Search.ToLower()) || u.LastName.ToLower().Contains(Search.ToLower())).ToList();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return userDtos;
        }
        public UserAllDetailsDto? GetUserById(string id)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return null;
            var userDto = _mapper.Map<UserAllDetailsDto>(user);
            return userDto;
        }
        public bool UpdateUser(UpdatedUserDto updatedUser)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == updatedUser.Id);
            if (user != null)
            {
                //user.FirstName = updatedUser.FirstName;
                //user.LastName = updatedUser.LastName;
                //user.PhoneNumber = updatedUser.PhoneNumber;
                _mapper.Map(updatedUser, user);
                var res = _userManager.UpdateAsync(user).Result;
                if (res.Succeeded)
                    return true;
            }
            return false;
        }
        public bool DeleteUser(string id)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return false;
            var res = _userManager.DeleteAsync(user).Result;
            if (res.Succeeded)
                return true;
            return false;
        }

    }
}
