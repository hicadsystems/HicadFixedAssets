using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Repositories;
using FixedAssetCore.Entities;
using FixedAssetCore.EntityCoreVM;
using FixedAssetCore.IRepositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FixedAssetCore.Repositories
{
    public class AssetDisposalRepo : Repository<fa_assetDisposal>, IAssetDisposalRepo
    {
        private readonly IAssetDbContext context;
        private readonly string connectionstring;
        public AssetDisposalRepo(IAssetDbContext context, IConfiguration configuration) : base(context)
        {
            this.context = context;
            connectionstring = configuration.GetConnectionString("DefaultConnection");

        }

        public IEnumerable<AssetDisposalVM> AssetDisposal(SortAssetsRegListVM sortAssetsRegListVM)
        {
            if (sortAssetsRegListVM.startDate != null && sortAssetsRegListVM.endDate != null)
            {
                var result = context.fa_AssetDisposals.Where(assets => assets.Dispdate >= sortAssetsRegListVM.startDate && assets.Dispdate <= sortAssetsRegListVM.endDate)
                    .Join(context.nac_costcenters, assetRecord => assetRecord.Dept, costCenter => costCenter.unitcode, (assetRecord, costCenter) => new { assetRecord, costCenter })

                    .Select(disposalList => new AssetDisposalVM
                    {
                        assetCode = disposalList.assetRecord.assetCode,
                        assetDesc = disposalList.assetRecord.assetDesc,
                        Dept = disposalList.costCenter.unitdesc,
                        Dispdate = disposalList.assetRecord.Dispdate,
                        Dispval = disposalList.assetRecord.Dispval


                    }).ToList();

                return result;
            }
            else
            {
                var result = context.fa_AssetDisposals
                     .Join(context.nac_costcenters, assetRecord => assetRecord.Dept, costCenter => costCenter.unitcode, (assetRecord, costCenter) => new { assetRecord, costCenter })

                    .Select(disposalList => new AssetDisposalVM
                    {
                        assetCode = disposalList.assetRecord.assetCode,
                        assetDesc = disposalList.assetRecord.assetDesc,
                        Dept = disposalList.costCenter.unitdesc,
                        Dispdate = disposalList.assetRecord.Dispdate,
                        Dispval = disposalList.assetRecord.Dispval


                    }).ToList();

                return result;
            }
        }
    }
}
