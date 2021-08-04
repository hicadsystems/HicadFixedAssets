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
    public class AssetMovementService : IAssetMovementService
    {
        private readonly IUnitOfWork unitOfWork;
        public AssetMovementService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<fa_Assetsreg> GetAllAssets()
        {
            return unitOfWork.assetMovementRepository.All();
        }

        public IEnumerable<nac_costcenters> GetAllCostCenters()
        {
            return unitOfWork.cost.All();
        }

        public CostCenterDescriptionVM GetCenterDescriptionWithAssetCode(string assetcode)
        {
            return unitOfWork.assetMovementRepository.GetCenterDescription(assetcode);
        }
    }
}
