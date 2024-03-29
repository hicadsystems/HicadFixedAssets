﻿using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.EntityCoreVM;
using FixedAssetWeb.IServices;
using FixedAssetWeb.ViewModels.AssetMovementVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.Services
{
    public class AssetRegService : IAssetRegisterationService
    {
        private IUnitOfWork unitOfWork;
        public AssetRegService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> AddAssetReg(fa_Assetsreg bl_sheet)
        {
            unitOfWork.reg.Create(bl_sheet);
            return await unitOfWork.Done();
        }

        public IEnumerable<fa_Assetsreg> GetAssetReg()
        {
            return unitOfWork.reg.All();
        }

        public IEnumerable<AssetRegListVM> GetAllAssetReg()
        {
            return unitOfWork.reg.GetAllAssetRegisters();
        }

        public Task<fa_Assetsreg> GetAssetRegByCode(string bcode)
        {
            return unitOfWork.reg.getAssetRegByCode(bcode);
        }

        public IEnumerable<AssetRegListVM> GetAssetRegByClasscode(string classCode)
        {
            return unitOfWork.reg.GetAssetsRegByClasscode(classCode);
        }

        public IEnumerable<fa_AssetRegVM> GetInsuranceRenewalReports(string assetCode)
        {
            return unitOfWork.reg.GetInsuranceReports(assetCode);
        }

        public IEnumerable<AssetRegListVM> GetAssetRegByDept(string dept)
        {
            return unitOfWork.reg.GetAssetsRegByDeptcode(dept);
        }
        
        public Task<fa_Assetsreg> GetAssetRegById(int id)
        {
            return unitOfWork.reg.Find(id);
        }

        public IEnumerable<AssetRegListVM> SortAssetRegList(SortAssetsRegListVM sortAssetsRegListVM)
        {
            return unitOfWork.reg.SortAssetsRegister(sortAssetsRegListVM);
        }
        public void RemoveAssetReg(fa_Assetsreg bl_sheet)
        {
            unitOfWork.reg.Remove(bl_sheet);
            unitOfWork.Done();
        }

        public async Task<bool> UpdateAssetReg(fa_Assetsreg bl_sheet)
        {
            unitOfWork.reg.Update(bl_sheet);
            return await unitOfWork.Done();
        }

        public string AssetRegEval(fa_AssetRegVM fa_AssetRegVM)
        {
            string response = unitOfWork.reg.AssetEval(fa_AssetRegVM);

            return response;
        }

    }
}
