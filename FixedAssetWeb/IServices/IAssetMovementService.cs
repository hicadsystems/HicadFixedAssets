﻿using FixedAssetCore.Core.Entities;
using FixedAssetCore.EntityCoreVM;
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
    }
}
