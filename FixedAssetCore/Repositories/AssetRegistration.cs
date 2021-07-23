using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssetCore.Core.Repositories
{
    public class AssetRegistration : Repository<fa_Assetsreg>, IAssetRegistration
    {
        private readonly IAssetDbContext context;

        public AssetRegistration(IAssetDbContext context):base(context)
        {
            this.context = context;
        }
        public Task<fa_Assetsreg> getAssetRegByCode(string code)
        {
            return context.fa_Assetsreg.FirstOrDefaultAsync(x => x.assetCode == code);
        }
    }
}
