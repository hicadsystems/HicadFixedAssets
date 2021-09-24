﻿using FixedAssetCore.Core.IRepositories;
using FixedAssetCore.Entities;
using FixedAssetCore.EntityCoreVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace FixedAssetCore.IRepositories
{
    public interface IAssetDisposalRepo : IRepository<fa_assetDisposal>
    {
        IEnumerable<AssetDisposalVM> AssetDisposal(SortAssetsRegListVM sortAssetsRegListVM);
    }
}
