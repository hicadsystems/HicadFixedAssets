﻿using FixedAssetCore.Core.Entities;
using FixedAssetCore.EntityCoreVM;
using FixedAssetWeb.ViewModels.AssetMovementVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.IServices
{
    public interface IAssetRegisterationService
    {
        IEnumerable<fa_Assetsreg> GetAssetReg();

        IEnumerable<AssetRegListVM> GetAllAssetReg();
        void RemoveAssetReg(fa_Assetsreg bl_sheet);
        Task<fa_Assetsreg> GetAssetRegById(int id);
        Task<bool> AddAssetReg(fa_Assetsreg bl_sheet);
        Task<fa_Assetsreg> GetAssetRegByCode(string bcode);
        IEnumerable<AssetRegListVM> GetAssetRegByClasscode(string classCode);
        IEnumerable<fa_AssetRegVM> GetInsuranceRenewalReports(string assetCode);
        IEnumerable<AssetRegListVM> SortAssetRegList(SortAssetsRegListVM sortAssetsRegListVM);
        IEnumerable<AssetRegListVM> GetAssetRegByDept(string dept);
        Task<bool> UpdateAssetReg(fa_Assetsreg bl_sheet);
        string AssetRegEval(fa_AssetRegVM fa_AssetRegVM);
    }
}
