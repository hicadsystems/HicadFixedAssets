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
    public class AssetClassification:Repository<fa_class>,IAssetClass
    {
        private readonly IAssetDbContext context;
        public AssetClassification(IAssetDbContext context):base(context)
        {
            this.context = context;
        }

        public Task<fa_class> GetClassByCode(string code)
        {
            return context.fa_class.FirstOrDefaultAsync(x => x.classcode == code);
        }
    }
}
