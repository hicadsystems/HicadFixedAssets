using FixedAssetCore.EntityCoreVM;
using FixedAssetWeb.IServices;
using FixedAssetWeb.ViewModels.Reports;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace FixedAssetWeb.Controllers
{
    public class MonthEndProcessingController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IGenerateDepreciationService _generateDepreciationService;
        private readonly IGeneratePdf _generatePdf;

        public MonthEndProcessingController(ICompanyService companyService, IGenerateDepreciationService generateDepreciationService, IGeneratePdf generatePdf)
        {
            _generateDepreciationService = generateDepreciationService;
            _companyService = companyService;
            _generatePdf = generatePdf;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GenerateDepreciation()
        {
            return View();
        }

        public IActionResult UpdateAssetDepreciation()
        {
            return View();
        }

        [Route("MonthEndProcessing/PrintDeprValue/{startDate}/{endDate}")]
        public async Task<IActionResult> PrintDeprValue( DateTime? startDate, DateTime? endDate)
        {
            var sortAssetsRegListVMv = new SortAssetsRegListVM()
            {
                startDate = startDate,
                endDate = endDate
            };


            var deprval = new ReportVM
            {
                Company = _companyService.GetCompanySingleRecord(),
                DepreciationValueReport = _generateDepreciationService.SortAssetsDeprecation(sortAssetsRegListVMv)
            };

            return await _generatePdf.GetPdf("Views/MonthEndProcessing/PrintDeprValue.cshtml", deprval);
        }
    }
}
