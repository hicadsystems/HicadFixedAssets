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

        public IEnumerable<DepreciationVM> SortDepreciationScheduleByClass(string classCode)
        {
            try
            {
                List<DepreciationVM> depreciationVMs = new List<DepreciationVM>();

                var depreciationGroup = DepreciationScheduleForClass(classCode).GroupBy(x => x.newclass).ToList();

                foreach (var assetLists in depreciationGroup)
                {
                    foreach (var asset in assetLists)
                    {
                        depreciationVMs.Add(new DepreciationVM
                        {
                            newclasscode = asset.newclasscode,
                            newclass = asset.newclass,
                            purchval = asset.purchval,
                            purchdate = asset.purchdate,
                            depreciation = asset.depreciation,
                            accum_depr = asset.accum_depr,
                            bookval = asset.bookval
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

        public IEnumerable<DepreciationVM> GroupDeprecitionScheduleByClass(string classCode)
        {
            try
            {
                List<DepreciationVM> depreciationClass = new List<DepreciationVM>();

                var depreciationGroup = DepreciationScheduleForClass(classCode).OrderBy(x => x.newclass).DistinctBy(x => x.newclass);

                foreach (var asset in depreciationGroup)
                {
                    depreciationClass.Add(new DepreciationVM
                    {
                        newclass = asset.newclass
                    });
                }

                return depreciationClass;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<DepreciationVM> SortDepreciationScheduleByDept(string dept)
        {
            try
            {
                List<DepreciationVM> depreciationVMs = new List<DepreciationVM>();

                var depreciationGroup = DepreciationScheduleForDept(dept).GroupBy(x => x.loc).ToList();

                foreach (var assetLists in depreciationGroup)
                {
                    foreach (var asset in assetLists)
                    {
                        depreciationVMs.Add(new DepreciationVM
                        {
                            loc = dept,
                            newloc = asset.newloc,
                            purchval = asset.purchval,
                            purchdate = asset.purchdate,
                            depreciation = asset.depreciation,
                            accum_depr = asset.accum_depr,
                            bookval = asset.bookval
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

        public IEnumerable<DepreciationVM> GroupDeprecitionScheduleByDept(string dept)
        {
            try
            {
                List<DepreciationVM> depreciationClass = new List<DepreciationVM>();

                var depreciationGroup = DepreciationScheduleForDept(dept).OrderBy(x => x.loc).DistinctBy(x => x.loc);

                foreach (var asset in depreciationGroup)
                {
                    depreciationClass.Add(new DepreciationVM
                    {
                        loc = asset.loc,
                        newloc = asset.newloc
                    });
                }

                return depreciationClass;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IEnumerable<DepreciationVM> DepreciationScheduleForClass(string classCode)
        {
            if (!string.IsNullOrEmpty(classCode.Trim()) && !string.IsNullOrWhiteSpace(classCode.Trim()) && classCode.Trim() != "null")
            {
                try
                {
                    var classEntity = context.fa_class.FirstOrDefault(x => x.classcode == classCode);

                    var result = context.fa_gdepreciations.Where(asset => asset.newclass == classEntity.classdesc)
                        .Select(assetsOfClass => new DepreciationVM
                        {
                            newclasscode = classCode,
                            newclass = assetsOfClass.newclass,
                            purchval = assetsOfClass.purchval,
                            purchdate = assetsOfClass.purchdate,
                            depreciation = assetsOfClass.depreciation,
                            accum_depr = assetsOfClass.accum_depr,
                            bookval = assetsOfClass.bookval

                        }).ToList();

                    return result;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                try
                {
                    var result = context.fa_gdepreciations
                        .Select(assetsOfClass => new DepreciationVM
                        {
                            newclasscode = classCode,
                            newclass = assetsOfClass.newclass,
                            purchval = assetsOfClass.purchval,
                            purchdate = assetsOfClass.purchdate,
                            depreciation = assetsOfClass.depreciation,
                            accum_depr = assetsOfClass.accum_depr,
                            bookval = assetsOfClass.bookval

                        }).ToList();

                    return result;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        private IEnumerable<DepreciationVM> DepreciationScheduleForDept(string dept)
        {
            if (!string.IsNullOrEmpty(dept.Trim()) && !string.IsNullOrWhiteSpace(dept.Trim()) && dept.Trim() != "null")
            {
                try
                {
                    var deptEntity = context.nac_costcenters.FirstOrDefault(x => x.unitcode == dept);

                    var result = context.fa_gdepreciations.Where(asset => asset.loc == dept)
                        .Select(assetsOfDept => new DepreciationVM
                        {
                            loc = assetsOfDept.loc,
                            newloc = deptEntity.unitdesc,
                            purchval = assetsOfDept.purchval,
                            purchdate = assetsOfDept.purchdate,
                            depreciation = assetsOfDept.depreciation,
                            accum_depr = assetsOfDept.accum_depr,
                            bookval = assetsOfDept.bookval

                        }).ToList();

                    return result;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                try
                {

                    var result = context.fa_gdepreciations
                        .Join(context.nac_costcenters, al => al.loc, costcnt => costcnt.unitcode, (al, costcnt) => new { al, costcnt })
                        .Select(assetsOfDept => new DepreciationVM
                        {
                            loc = assetsOfDept.al.loc,
                            newloc = assetsOfDept.costcnt.unitdesc,
                            purchval = assetsOfDept.al.purchval,
                            purchdate = assetsOfDept.al.purchdate,
                            depreciation = assetsOfDept.al.depreciation,
                            accum_depr = assetsOfDept.al.accum_depr,
                            bookval = assetsOfDept.al.bookval

                        }).ToList();

                    return result;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public IEnumerable<DepreciationVM> SortDepreciationScheduleByBusinessLine(string busline)
        {
            try
            {
                List<DepreciationVM> depreciationVMs = new List<DepreciationVM>();

                var depreciationGroup = DepreciationScheduleForBusinessLine(busline).GroupBy(x => x.busline).ToList();

                foreach (var assetLists in depreciationGroup)
                {
                    foreach (var asset in assetLists)
                    {
                        depreciationVMs.Add(new DepreciationVM
                        {
                            busline = busline,
                            busdesc = asset.busdesc,
                            purchval = asset.purchval,
                            purchdate = asset.purchdate,
                            depreciation = asset.depreciation,
                            accum_depr = asset.accum_depr,
                            bookval = asset.bookval
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

        public IEnumerable<DepreciationVM> GroupDeprecitionScheduleByBusinessLine(string busline)
        {
            try
            {
                List<DepreciationVM> depreciationClass = new List<DepreciationVM>();

                var depreciationGroup = DepreciationScheduleForBusinessLine(busline).OrderBy(x => x.busline).DistinctBy(x => x.busline);

                foreach (var asset in depreciationGroup)
                {
                    depreciationClass.Add(new DepreciationVM
                    {
                        busline = asset.busline,
                        busdesc = asset.busdesc
                    });
                }

                return depreciationClass;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IEnumerable<DepreciationVM> DepreciationScheduleForBusinessLine(string busline)
        {
            if (!string.IsNullOrEmpty(busline.Trim()) && !string.IsNullOrWhiteSpace(busline.Trim()) && busline.Trim() != "null")
            {
                try
                {
                    var result = context.fa_gdepreciations.Where(asset => asset.busline == busline)
                        .Join(context.nac_businessline, al => al.busline, bsline => bsline.Code, (al, bsline) => new { al, bsline })
                        .Select(assetsOfBusLine => new DepreciationVM
                        {
                            busline = assetsOfBusLine.al.busline,
                            busdesc = assetsOfBusLine.bsline.Description,
                            purchval = assetsOfBusLine.al.purchval,
                            purchdate = assetsOfBusLine.al.purchdate,
                            depreciation = assetsOfBusLine.al.depreciation,
                            accum_depr = assetsOfBusLine.al.accum_depr,
                            bookval = assetsOfBusLine.al.bookval

                        }).ToList();

                    return result;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                try
                {
                    var result = context.fa_gdepreciations
                        .Join(context.nac_businessline, al => al.busline, bsline => bsline.Code, (al, bsline) => new { al, bsline })
                        .Select(assetsOfBusLine => new DepreciationVM
                        {
                            busline = assetsOfBusLine.al.busline,
                            busdesc = assetsOfBusLine.bsline.Description,
                            purchval = assetsOfBusLine.al.purchval,
                            purchdate = assetsOfBusLine.al.purchdate,
                            depreciation = assetsOfBusLine.al.depreciation,
                            accum_depr = assetsOfBusLine.al.accum_depr,
                            bookval = assetsOfBusLine.al.bookval

                        }).ToList();

                    return result;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public IEnumerable<DepreciationNoteVM> DepreciationNote(string classCode, string month, string year)
        {
            var depreAssets = new List<DepreciationNoteVM>();

            if (!string.IsNullOrEmpty(classCode) && !string.IsNullOrEmpty(month) && !string.IsNullOrEmpty(year) && classCode != "null")
            {
                try
                {
                    var classcode = context.fa_class.FirstOrDefault(x => x.classcode == classCode);

                    //get's all records that belongs to a particular class
                    var allAssetsInclass = context.fa_gdepreciations.Where(asset => asset.newclass == classcode.classdesc.Trim() && asset.assetmonth == month.Trim() && asset.assetyear == year.Trim()).ToList();

                    foreach (var assetRec in allAssetsInclass)
                    {
                        //sum properties of a record that belongs to a particular class and adds them to a Depreciation Note Model
                        depreAssets.Add(new DepreciationNoteVM
                        {
                            Class = allAssetsInclass.FirstOrDefault().newclass,
                            Cost = allAssetsInclass.Sum(x => x.purchval),
                            CostStartDate = string.Format("{0:MM/dd/yyyy}", allAssetsInclass.FirstOrDefault().purchdate),
                            Additions = allAssetsInclass.Count(),
                            // Reclassifications = deprecAssetList.LastOrDefault().r,
                            Disposal = 0,
                            Depreciation = allAssetsInclass.Sum(x => x.depreciation),
                            DepreciationStartDate = string.Format("{0:MM/dd/yyyy}", allAssetsInclass.FirstOrDefault().calc_date),
                            DepreciationEndDate = string.Format("{0:MM/dd/yyyy}", allAssetsInclass.FirstOrDefault().calc_date)

                        });
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                //Gets all Distinct classes on the fa_gdepreciations table
                var classes = context.fa_gdepreciations.DistinctBy(x => x.newclass).ToList();

                //loops through the list of classes
                foreach (var allrec in classes)
                {
                    //get's all records that belongs to a particular class
                    var getallrecInClass = context.fa_gdepreciations.Where(x => x.newclass == allrec.newclass).ToList();

                    //sum properties of a record that belongs to a particular class and adds them to a Depreciation Note Model
                    depreAssets.Add(new DepreciationNoteVM
                    {
                        Class = getallrecInClass.FirstOrDefault().newclass,
                        Cost = getallrecInClass.Sum(x => x.purchval),
                        CostStartDate = string.Format("{0:MM/dd/yyyy}", getallrecInClass.FirstOrDefault().purchdate),
                        Additions = getallrecInClass.Count(),
                        // Reclassifications = deprecAssetList.LastOrDefault().r,
                        Disposal = 0,
                        Depreciation = getallrecInClass.Sum(x => x.depreciation),
                        DepreciationStartDate = string.Format("{0:MM/dd/yyyy}", getallrecInClass.FirstOrDefault().calc_date),
                        DepreciationEndDate = string.Format("{0:MM/dd/yyyy}", getallrecInClass.FirstOrDefault().calc_date)

                    });
                }
            }

            return depreAssets;
        }

        public IEnumerable<DepreciationNoteVM> GetDepreciationNoteByClass(string classCode, string month, string year)
        {
            var depreciationClass = new List<DepreciationNoteVM>();

            var depreciatedAssets = DepreciationNoteRepo(classCode, month, year).OrderBy(x => x.newclass).DistinctBy(x => x.newclass);

            foreach (var assets in depreciatedAssets)
            {
                depreciationClass.Add(new DepreciationNoteVM
                {
                    Class = assets.newclass,
                });
            }

            return depreciationClass;
        }

        private IEnumerable<DepreciationVM> DepreciationNoteRepo(string classCode, string month, string year)
        {
            IEnumerable<DepreciationVM> result = null;

            if (!string.IsNullOrEmpty(classCode) && !string.IsNullOrEmpty(month) && !string.IsNullOrEmpty(year) && classCode != "null")
            {
                try
                {
                    result = context.fa_gdepreciations.Where(asset => asset.newclass == classCode.Trim() && asset.assetmonth == month.Trim() && asset.assetyear == year.Trim())
                        .Select(depreList => new DepreciationVM
                        {
                            oldclass = depreList.oldclass,
                            newclass = depreList.newclass,
                            purchdate = depreList.purchdate,
                            depreciation = depreList.depreciation,
                            bookval = depreList.bookval

                        }).ToList();
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            else if (!string.IsNullOrEmpty(month) && !string.IsNullOrEmpty(year))
            {
                try
                {
                    result = context.fa_gdepreciations.Where(asset => asset.assetmonth == month.Trim() && asset.assetyear == year.Trim())
                        .Select(depreList => new DepreciationVM
                        {
                            oldclass = depreList.oldclass,
                            newclass = depreList.newclass,
                            purchdate = depreList.purchdate,
                            depreciation = depreList.depreciation,
                            bookval = depreList.bookval

                        }).ToList();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return result;
        }
    }
}
