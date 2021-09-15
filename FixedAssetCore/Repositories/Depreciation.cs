using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Repositories;
using FixedAssetCore.Entities;
using FixedAssetCore.EntityCoreVM;
using FixedAssetCore.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FixedAssetCore.Repositories
{
    public class Depreciation : Repository<fa_gdepreciation>, IDepreciation
    {
        private readonly IAssetDbContext context;
        public Depreciation(IAssetDbContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<DepreciationVM> SortAssetsDeprecation(SortAssetsRegListVM sortAssetsRegListVM)
        {
            var result = context.fa_gdepreciations.Where(assets => assets.purchdate >= sortAssetsRegListVM.startDate && assets.purchdate <= sortAssetsRegListVM.endDate)
                .Select(depreciationVm => new DepreciationVM
                {
                    Id = depreciationVm.Id,
                    assetcode = depreciationVm.assetcode,
                    assetdesc = depreciationVm.assetdesc,
                    purchdate = depreciationVm.purchdate,
                    purchval = depreciationVm.purchval,
                    depreciation = depreciationVm.depreciation,
                    accum_depr = depreciationVm.accum_depr,
                    bookval = depreciationVm.bookval

                }).ToList();

            return result;
        }
    }
}
