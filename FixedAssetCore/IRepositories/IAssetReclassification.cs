using FixedAssetCore.Core.Entities;
using FixedAssetCore.Core.IRepositories;
using FixedAssetCore.EntityCoreVM;
using FixedAssetWeb.ViewModels.AssetMovementVM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssetCore.IRepositories
{
    public interface IAssetReclassification : IRepository<fa_Assetsreg>
    {
        ClassDescriptionVM GetClassDescription(string assetcode);

        void UpdateAssetReg(fa_AssetRegVM fa_assetsregVm);
    }
}
