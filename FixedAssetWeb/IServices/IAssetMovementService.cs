using FixedAssetCore.Core.Entities;
using FixedAssetCore.EntityCoreVM;
using FixedAssetWeb.ViewModels.AssetMovementVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.IServices
{
    public interface IAssetMovementService
    {
        IEnumerable<fa_Assetsreg> GetAllAssets();

        IEnumerable<nac_costcenters> GetAllCostCenters();

        CostCenterDescriptionVM GetCenterDescriptionWithAssetCode(string assetcode);

        void UpdateAssetDepartment(fa_AssetRegVM fa_AssetsregVm);

        IEnumerable<fa_historyVM> GetAssetNovementList(SortAssetsRegListVM sortAssetsRegListVM);
    }
}
