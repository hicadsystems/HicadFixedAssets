using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FixedAssetCore.Core.Repositories
{
    public class MenuGroupRepository:Repository<fa_MenuGroup>,IMenuGroupRepository
    {
        private readonly IAssetDbContext context;

        public MenuGroupRepository(IAssetDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
