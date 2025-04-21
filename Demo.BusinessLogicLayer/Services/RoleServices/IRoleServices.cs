using Demo.BusinessLogicLayer.DTOS.RoleDTOS;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Services.RoleServices
{
    public interface IRoleServices
    {
        IEnumerable<RoleDto> GetAllRoles(string? Search);
        RoleDto? GetRoleById(string id);
        bool CreateRole(CreatedRole role);
        bool UpdateRole(RoleDto role);
        bool DeleteRole(RoleDto role);
    }
}
