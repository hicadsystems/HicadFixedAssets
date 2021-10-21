using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Repositories;
using FixedAssetCore.Entities;
using FixedAssetCore.EntityCoreVM;
using FixedAssetCore.IRepositories;
using MoreLinq;
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

        public string UpdateAssetDeprecation(string month, string year)
        {
            var assetLists = context.fa_gdepreciations.Where(asset => asset.assetmonth == month.Trim() && asset.assetyear == year.Trim());

            if (assetLists.Count() == 0)
            {
                return "No Assets depreciation records found for date range: Month " + month + " and year " + year;
            }
            else
            {
                foreach (var assetList in assetLists)
                {
                    var assetReg = context.fa_Assetsreg.Where(asset => asset.assetCode == assetList.assetcode).FirstOrDefault();
                    assetReg.Accum_depre = assetList.accum_depr;

                    context.fa_Assetsreg.Update(assetReg);
                }

                var company = context.nac_company.FirstOrDefault();
                company.processmonth = month;
                company.Processyear = year;

                context.nac_company.Update(company);

                return "Assets Depreciation updated successfully for date range: Month " + month + " and year " + year;
            }
        }

        public IEnumerable<DepreciationVM> SortDepreciationByClass(string month, string year)
        {
            try
            {
                List<DepreciationVM> depreciationVMs = new List<DepreciationVM>();

                var depreciationGroup = SortDepreciationByMonthAndYear(month, year).GroupBy(x => x.newclass).ToList();

                foreach (var assetLists in depreciationGroup)
                {
                    foreach (var asset in assetLists)
                    {
                        depreciationVMs.Add(new DepreciationVM
                        {
                            assetcode = asset.assetcode,
                            assetdesc = asset.assetdesc,
                            purchdate = asset.purchdate,
                            purchval = asset.purchval,
                            depreciation = asset.depreciation,
                            newclass = asset.newclass,
                            newloc = asset.newloc,
                            busline = asset.busline,
                        });
                    }
                }

                return depreciationVMs;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<DepreciationVM> GroupDeprecitionClass(string month, string year)
        {
            try
            {
                List<DepreciationVM> depreciationClass = new List<DepreciationVM>();

                var depreciationGroup = SortDepreciationByMonthAndYear(month, year).OrderBy(x => x.newclass).DistinctBy(x => x.newclass);

                foreach (var asset in depreciationGroup)
                {
                    depreciationClass.Add(new DepreciationVM
                    {
                        assetcode = asset.assetcode,
                        assetdesc = asset.assetdesc,
                        purchdate = asset.purchdate,
                        purchval = asset.purchval,
                        depreciation = asset.depreciation,
                        newclass = asset.newclass,
                        newloc = asset.newloc,
                        busline = asset.busline,
                    });
                }

                return depreciationClass;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private IEnumerable<DepreciationVM> SortDepreciationByMonthAndYear(string month, string year)
        {
            try
            {
                var result = context.fa_gdepreciations.Where(asset => asset.assetmonth == month && asset.assetyear == year)
                //.Join(context.fa_class, deprAsset => deprAsset.newclass, c => c.classcode, (deprAsset, c) => new { deprAsset, c })
                .Join(context.nac_costcenters, al => al.loc, costcnt => costcnt.unitcode, (al, costcnt) => new { al, costcnt })
                .Join(context.nac_businessline, abl => abl.al.busline, busline => busline.Code, (abl, busline) => new { abl.al, abl.costcnt, busline })
                .Select(assetsDepreciated => new DepreciationVM
                {
                    assetcode = assetsDepreciated.al.assetcode,
                    assetdesc = assetsDepreciated.al.assetdesc,
                    purchdate = assetsDepreciated.al.purchdate,
                    purchval = assetsDepreciated.al.purchval,
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
    }
}
