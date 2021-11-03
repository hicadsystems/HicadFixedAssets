using FixedAssetCore.Core.IRepositories;
using FixedAssetCore.Entities;
using FixedAssetCore.EntityCoreVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace FixedAssetCore.IRepositories
{
    public interface IDepreciation : IRepository<fa_gdepreciation>
    {
        IEnumerable<DepreciationVM> SortAssetsDeprecation(SortAssetsRegListVM sortAssetsRegListVM);
        IEnumerable<DepreciationVM> DeprecationSummary(string assetCode);
        string UpdateAssetDeprecation(string month, string year);
        IEnumerable<DepreciationVM> SortDepreciationByClass(string month, string year);
        IEnumerable<DepreciationVM> GroupDeprecitionClass(string month, string year);
        IEnumerable<DepreciationNoteVM> DepreciationNote(string classCode, string month, string year);
        IEnumerable<DepreciationVM> GroupDeprecitionScheduleByClass(string classCode);
        IEnumerable<DepreciationVM> SortDepreciationScheduleByDept(string dept);
        IEnumerable<DepreciationVM> GroupDeprecitionScheduleByDept(string dept);
        IEnumerable<DepreciationVM> SortDepreciationScheduleByBusinessLine(string busline);
        IEnumerable<DepreciationVM> GroupDeprecitionScheduleByBusinessLine(string busline);
        IEnumerable<DepreciationVM> SortDepreciationScheduleByClass(string classCode);
        IEnumerable<DepreciationNoteVM> GetDepreciationNoteByClass(string classCode, string month, string year);
    }
}
