using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.EntityCoreVM;
using FixedAssetWeb.IServices;
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

        public Task<fa_Assetsreg> GetAssetRegById(int id)
        {
            return unitOfWork.reg.Find(id);
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

    }
}
