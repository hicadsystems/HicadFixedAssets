using FixedAssetCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssetCore.Core.IRepositories
{
    public interface IUserRepository:IRepository<User>
    {
        Task<User> UserWithRoles(Expression<Func<User, bool>> predicate);
        Task<User> UserWithRolesandMenus(Expression<Func<User, bool>> predicate);
        Task<User> User(Expression<Func<User, bool>> predicate);
    }
}
