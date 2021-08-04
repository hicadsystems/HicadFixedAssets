using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.Core.Repositories;
using FixedAssetCore.EntityCoreVM;
using FixedAssetCore.IRepositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FixedAssetCore.Repositories
{
    public class AssetMovementRepository : Repository<fa_Assetsreg>, IAssetMovementRepository
    {
        private readonly IAssetDbContext context;
        private readonly string connectionstring;
        public AssetMovementRepository(IAssetDbContext context, IConfiguration configuration) : base(context)
        {
            this.context = context;
            connectionstring = configuration.GetConnectionString("DefaultConnection");
        }

        public CostCenterDescriptionVM GetCenterDescription(string assetcode)
        {
            var result = context.fa_Assetsreg.Where(x => x.assetCode == assetcode)
                .Join(context.nac_costcenters, asset => asset.Dept, c => c.unitcode, (asset, c) => new { asset, c })
                .Select(y => new CostCenterDescriptionVM
                {
                    AssetCode = y.asset.assetCode,
                    oldUnitCode = y.c.unitcode,
                    UnitCodeDescription = y.c.unitdesc
                }).FirstOrDefault();

            return result;
        }
    }
}
