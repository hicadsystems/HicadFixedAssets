using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.Core.Repositories;
using FixedAssetCore.EntityCoreVM;
using FixedAssetWeb.IServices;
using FixedAssetWeb.ViewModels.AssetMovementVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.Services
{
    public class AssetReclassificationService : IAssetReclassificationService
    {
        private readonly IUnitOfWork unitOfWork;
        public AssetReclassificationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<fa_Assetsreg> GetAssets()
        {
            return unitOfWork.assetReclassification.All();
        }

        public ClassDescriptionVM GetClassDescriptionWithAssetCode(string assetcode)
        {
            return unitOfWork.assetReclassification.GetClassDescription(assetcode);
        }

        public Task<fa_Assetsreg> GetAssetByAssetCode(string code)
        {

            return unitOfWork.assetReclassification.FindCode(code);
        }

        public IEnumerable<fa_class> GetClassifications()
        {
            return unitOfWork.assetClass.All();
        }

        public Task<fa_class> GetClassificationByCode(string code)
        {
            return unitOfWork.assetClass.GetClassByCode(code);
        }

        public void UpdateAssetClassification(fa_AssetRegVM fa_assetsregVm)
        {
            unitOfWork.assetReclassification.UpdateAssetReg(fa_assetsregVm);
            unitOfWork.Done();
        }
    }
}
