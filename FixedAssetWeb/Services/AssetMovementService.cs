using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.Core.Repositories;
using FixedAssetWeb.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.Services
{
    public class AssetMovementService : IAssetMovementService
    {
        private readonly IUnitOfWork unitOfWork;
        public AssetMovementService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<fa_Assetsreg> GetAssets()
        {
            return unitOfWork.assetMovement.All();
        }

        public Task<fa_Assetsreg> GetAssetByAssetCode(string code)
        {
            return unitOfWork.assetMovement.GetAssetByCode(code);
        }

        public IEnumerable<fa_class> GetClassifications()
        {
            return unitOfWork.assetClass.All();
        }

        public Task<fa_class> GetClassificationByCode(string code)
        {
            return unitOfWork.assetClass.GetClassByCode(code);
        }

        public Task<bool> UpdateAssetClassification(fa_Assetsreg fa_Assetsreg)
        {
          return  unitOfWork.assetMovement.UpdateAsset(fa_Assetsreg);  
        }
    }
}
