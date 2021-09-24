using FixedAssetCore.Core.Data;
using FixedAssetCore.EntityCoreVM;
using FixedAssetWeb.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.Services
{
    public class AssetDisposalService : IAssetDisposalService
    {
        private IUnitOfWork unitOfWork;

        public AssetDisposalService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }
        public IEnumerable<AssetDisposalVM> AssetDisposalList(SortAssetsRegListVM sortAssetsRegListVM)
        {
            return unitOfWork.assetDisposalRepo.AssetDisposal(sortAssetsRegListVM);
        }

    }
}
