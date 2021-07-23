using FixedAssetCore.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.IServices
{
    public interface IRoleService
    {
        IEnumerable<Role> GetRoles();
        IEnumerable<Role> GetActiveRoles();
        Task<bool> AddRole(Role role, int[] menus);
        Task<Role> GetRoleById(int id);
        Task<IdentityResult> UpdateRole(Role role);
        Task<Role> GetRoleWithMenuById(int id);
        Task<Role> GetRoleByName(string name);
        Task<IdentityResult> UpdateRoleInfo(Role role, int[] menus);
    }
}
