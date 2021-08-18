using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetWeb.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.Services
{
    public class AssetClassService: IAssetClassService
    {
        private readonly IUnitOfWork unitOfWork;
        public AssetClassService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> AddClass(fa_class bl_sheet)
        {
            unitOfWork.assetClass.Create(bl_sheet);
            return await unitOfWork.Done();
        }

        public IEnumerable<fa_class> GetClass()
        {
            return unitOfWork.assetClass.All();
        }

        public Task<fa_class> GetClassByCode(string bcode)
        {
            return unitOfWork.assetClass.GetClassByCode(bcode);
        }

        public Task<fa_class> GetClassById(int id)
        {
            return unitOfWork.assetClass.Find(id);
        }

        public void RemoveClass(fa_class bl_sheet)
        {
            unitOfWork.assetClass.Remove(bl_sheet);
            unitOfWork.Done();
        }

        public Task<bool> UpdateClass(fa_class bl_sheet)
        {
            unitOfWork.assetClass.Update(bl_sheet);
            return unitOfWork.Done();
        }
    }
}
