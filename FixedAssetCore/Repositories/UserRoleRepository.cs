using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FixedAssetCore.Core.Repositories
{
    public class UserRoleRepository:Repository<UserRole>,IUserRoleRepository
    {
        private readonly IAssetDbContext context;
        public UserRoleRepository(IAssetDbContext context) :base(context)
        {
            this.context = context;
        }


    }
}
