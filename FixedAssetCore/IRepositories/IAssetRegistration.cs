﻿using FixedAssetCore.Core.Entities;
using FixedAssetCore.EntityCoreVM;
using FixedAssetWeb.ViewModels.AssetMovementVM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssetCore.Core.IRepositories
{
    public interface IAssetRegistration:IRepository<fa_Assetsreg>
    {
        Task<fa_Assetsreg> getAssetRegByCode(string code);

        IEnumerable<fa_Assetsreg> GetAssetsRegByClasscode(string classCode);

        IEnumerable<AssetRegListVM> GetAllAssetRegisters();

        string GenerateAssetsDepreciation(string username, DateTime dateTime);

        string AssetEval(fa_AssetRegVM fa_AssetRegVM);
    }
}
