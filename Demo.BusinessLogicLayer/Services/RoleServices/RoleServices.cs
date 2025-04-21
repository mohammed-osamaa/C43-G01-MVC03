using AutoMapper;
using Demo.BusinessLogicLayer.DTOS.RoleDTOS;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Services.RoleServices
{
    public class RoleServices(RoleManager<IdentityRole> _roleManager , IMapper _mapper) : IRoleServices
    {
        public IEnumerable<RoleDto> GetAllRoles(string? Search)
        {
            IEnumerable<IdentityRole> roles;
            if (string.IsNullOrWhiteSpace(Search))
                roles = _roleManager.Roles.ToList();
            else
                roles = _roleManager.Roles.Where(R => R.Name.ToLower().Contains(Search.ToLower())).ToList();
            var RolesDtos = _mapper.Map<IEnumerable<RoleDto>>(roles);
            return RolesDtos;
        }
        public RoleDto? GetRoleById(string id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            if (role == null)
                return null;
            var roleDto = _mapper.Map<RoleDto>(role);
            return roleDto;
        }
        public bool CreateRole(CreatedRole dto)
        {
            var role = _mapper.Map<IdentityRole>(dto);
            var result = _roleManager.CreateAsync(role).Result;
            if(result.Succeeded)
                return true;
            return false;
        }
        public bool UpdateRole(RoleDto role)
        {
            var roleToUpdate = _roleManager.Roles.FirstOrDefault(x => x.Id == role.Id);
            if (roleToUpdate == null)
                return false;
            _mapper.Map(role, roleToUpdate);
            var result = _roleManager.UpdateAsync(roleToUpdate).Result;
            if (result.Succeeded)
                return true;
            return false;
        }
        public bool DeleteRole(RoleDto role)
        {
            var roleToDelete = _roleManager.FindByIdAsync(role.Id).Result;
            if (roleToDelete != null)
            {
                var result = _roleManager.DeleteAsync(roleToDelete).Result;
                if (result.Succeeded)
                    return true;
            }
            return false;
        }
    }
}
