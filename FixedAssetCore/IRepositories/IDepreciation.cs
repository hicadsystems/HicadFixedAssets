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
        IEnumerable<DepreciationNoteVM> GetDepreciationNoteByClass(string classCode, string month, string year);
    }
}
