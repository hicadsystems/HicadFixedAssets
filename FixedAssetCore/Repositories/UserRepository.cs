using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssetCore.Core.Repositories
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        private readonly IAssetDbContext context;
        public UserRepository(IAssetDbContext context):base(context)
        {
            this.context = context;
        }

        public async Task<User> User(Expression<Func<User, bool>> predicate)
        {
            var reu = await context.Users
               .Include(x => x.UserRoles)
               .ThenInclude(x => x.Role)
               .FirstOrDefaultAsync(predicate);

            return reu;
        }

        public async Task<User> UserWithRoles(Expression<Func<User, bool>> predicate)
        {
            return await context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role).FirstOrDefaultAsync(predicate);
          
        }
    

        public async Task<User> UserWithRolesandMenus(Expression<Func<User, bool>> predicate)
        {
            return await context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .ThenInclude(x => x.fa_RoleMenus)
                .ThenInclude(x => x.fa_Menu)
                .ThenInclude(x => x.MenuGroup)
                .FirstOrDefaultAsync(predicate);
        }
    }
}
