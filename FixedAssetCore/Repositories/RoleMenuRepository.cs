using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FixedAssetCore.Core.Repositories
{
    public class RoleMenuRepository : Repository<fa_RoleMenu>, IRoleMenuRepository
    {
        private readonly IAssetDbContext context;

        public RoleMenuRepository(IAssetDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
