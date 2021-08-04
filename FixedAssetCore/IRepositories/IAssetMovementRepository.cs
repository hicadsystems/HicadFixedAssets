using FixedAssetCore.Core.Entities;
using FixedAssetCore.Core.IRepositories;
using FixedAssetCore.EntityCoreVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace FixedAssetCore.IRepositories
{
    public interface IAssetMovementRepository : IRepository<fa_Assetsreg>
    {
        CostCenterDescriptionVM GetCenterDescription(string assetcode);
    }
}
