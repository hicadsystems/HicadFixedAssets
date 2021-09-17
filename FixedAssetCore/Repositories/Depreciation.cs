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

        public IEnumerable<DepreciationVM> DeprecationSummary(string assetCode)
        {
            try
            {
                var result = context.fa_gdepreciations.Where(asset => asset.assetcode == assetCode)
                //.Join(context.fa_class, deprAsset => deprAsset.newclass, c => c.classcode, (deprAsset, c) => new { deprAsset, c })
                .Join(context.nac_costcenters, al => al.loc, costcnt => costcnt.unitcode, (al, costcnt) => new { al, costcnt })
                .Join(context.nac_businessline, abl => abl.al.busline, busline => busline.Code, (abl, busline) => new { abl.al, abl.costcnt, busline })
                .Select(assetsDepreciated => new DepreciationVM
                {
                    assetdesc = assetsDepreciated.al.assetdesc,
                    depreciation = assetsDepreciated.al.depreciation,
                    newclass = assetsDepreciated.al.newclass,
                    newloc = assetsDepreciated.costcnt.unitdesc,
                    busline = assetsDepreciated.busline.Description,
                }).ToList();

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<DepreciationVM> SortAssetsDeprecation(SortAssetsRegListVM sortAssetsRegListVM)
        {
            var result = context.fa_gdepreciations.Where(assets => assets.calc_date >= sortAssetsRegListVM.startDate && assets.calc_date <= sortAssetsRegListVM.endDate)
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
