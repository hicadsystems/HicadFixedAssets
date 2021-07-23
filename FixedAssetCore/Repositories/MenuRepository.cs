using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.Core.IRepositories;
using FixedAssetCore.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FixedAssetCore.Core.Repositories
{
    public class MenuRepository : Repository<fa_Menu>, IMenuRepository
    {
        private readonly IAssetDbContext context;
        public MenuRepository(IAssetDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
