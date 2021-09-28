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
    }
}
