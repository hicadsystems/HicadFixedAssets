using FixedAssetCore.Core.Data;
using FixedAssetCore.EntityCoreVM;
using FixedAssetWeb.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.Services
{
    public class GenerateDepreciationService : IGenerateDepreciationService
    {
        private IUnitOfWork unitOfWork;
        public GenerateDepreciationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<DepreciationVM> DeprecationSummaryReport(string assetCode)
        {
            var responseObject = unitOfWork.depreciation.DeprecationSummary(assetCode);

            return responseObject;
        }

        public string GenerateDepreciation(string username, DateTime dateTime)
        {
            string responseMessage = unitOfWork.reg.GenerateAssetsDepreciation(username, dateTime);

            return responseMessage;
        }

        public IEnumerable<DepreciationVM> SortAssetsDeprecation(SortAssetsRegListVM sortAssetsRegListVM)
        {
            var responseMessage = unitOfWork.depreciation.SortAssetsDeprecation(sortAssetsRegListVM);

            return responseMessage;
        }

        public string UpdateDepreciations(string month, string year)
        {
            string response = unitOfWork.depreciation.UpdateAssetDeprecation(month, year);
            unitOfWork.Done();

            return response;
        }
    }
}
