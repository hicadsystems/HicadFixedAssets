using FixedAssetCore.EntityCoreVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.IServices
{
    public interface IAssetDisposalService
    {
        IEnumerable<AssetDisposalVM> AssetDisposalList(SortAssetsRegListVM sortAssetsRegListVM);
    }
}
