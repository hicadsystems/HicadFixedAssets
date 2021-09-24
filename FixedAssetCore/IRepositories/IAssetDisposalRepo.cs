using FixedAssetCore.Core.IRepositories;
using FixedAssetCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FixedAssetCore.IRepositories
{
    public interface IAssetDisposalRepo : IRepository<fa_assetDisposal>
    {
        string AssetDisposal(string assetcode, decimal? curentValue);
    }
}
