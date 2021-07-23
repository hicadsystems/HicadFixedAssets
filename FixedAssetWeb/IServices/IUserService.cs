using FixedAssetCore.Core.Entities;
using FixedAssetCore.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.IServices
{
    public interface IUserService
    {
        Task<ResponseModel<User>> CreateUser(User user, IEnumerable<int> roles, string password, int? device);
        Task<User> GetUserWithRoles(int id);
        Task<User> GetUserByResetCode(string resetcode);
        IEnumerable<User> GetUsers();
        Task<User> GetUserByUserName(string username);
        Task<User> GetUserWithRolesAndMenus(int id);
        Task<User> GetUserRolesDevices(int id);
        Task<IdentityResult> UpdateUserInfo(User user, IEnumerable<int> roles, int? device);
        Task<IdentityResult> UpdateUser(User user);
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
    }
}
