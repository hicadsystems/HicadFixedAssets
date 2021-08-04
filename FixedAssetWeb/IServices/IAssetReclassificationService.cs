using FixedAssetCore.Core.Entities;
using FixedAssetCore.EntityCoreVM;
using FixedAssetWeb.ViewModels.AssetMovementVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.IServices
{
    public interface IAssetReclassificationService
    {
        IEnumerable<fa_Assetsreg> GetAssets();

        Task<fa_Assetsreg> GetAssetByAssetCode(string code);

        ClassDescriptionVM GetClassDescriptionWithAssetCode(string assetcode);

        IEnumerable<fa_class> GetClassifications();

        Task<fa_class> GetClassificationByCode(string code);

        void UpdateAssetClassification(fa_AssetRegVM fa_assetsregVm);
    }
}
