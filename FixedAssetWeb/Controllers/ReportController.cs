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
    public class ReportController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IGeneratePdf _generatePdf;
        private readonly IGenerateDepreciationService _generateDepreciation;
        private readonly IAssetMovementService _assetMovementService;
        private readonly IAssetRegisterationService _assetRegisterationService;
        public ReportController(ICompanyService companyService, IGeneratePdf generatePdf, IGenerateDepreciationService generateDepreciation, 
            IAssetMovementService assetMovementService, IAssetRegisterationService assetRegisterationService)
        {
            _companyService = companyService;
            _generatePdf = generatePdf;
            _generateDepreciation = generateDepreciation;
            _assetMovementService = assetMovementService;
            _assetRegisterationService = assetRegisterationService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AssetRegister()
        {
            return View();
        }

        public IActionResult DepreciationValue()
        {
            return View();
        }

        public IActionResult DepreciationSummary()
        {
            return View();
        }

        public IActionResult AssetMovement()
        {
            return View();
        }

        public IActionResult AdditionAndDisposal()
        {
            return View();
        }

        public IActionResult InsuranceRenewalnotice()
        {
            return View();
        }

        [Route("Report/PrintDepreciationSummary/{assetCode}")]
        public async Task<IActionResult> PrintDepreciationSummary(string assetCode)
        {
            var depreciationReport = new ReportVM
            {
                Company = _companyService.GetCompanySingleRecord(),
                DepreciationSummaryReport = _generateDepreciation.DeprecationSummaryReport(assetCode)
            };

            return await _generatePdf.GetPdf("Views/Report/PrintDepreciationSummary.cshtml", depreciationReport);
        }

        [Route("Report/InsuranceRenewalReport/{assetCode}")]
        public async Task<IActionResult> InsuranceRenewalReport(string assetCode)
        {
            var insuranceRenewalReport = new ReportVM
            {
                Company = _companyService.GetCompanySingleRecord(),
                InsuranceReport = _assetRegisterationService.GetInsuranceRenewalReports(assetCode.Trim()),
            };

            return await _generatePdf.GetPdf("Views/Report/InsuranceRenewalReport.cshtml", insuranceRenewalReport);
        }

        [Route("Report/PrintAssetMovement/{classCode}/{classDept}/{startDate}/{endDate}")]
        public async Task<IActionResult> PrintAssetMovement(string classCode, string classDept, DateTime? startDate, DateTime? endDate)
        {
            var sortAssetsRegListVMv = new SortAssetsRegListVM()
            {
                classCode = classCode,
                classDept = classDept,
                startDate = startDate,
                endDate = endDate
            };

            var assetMovementReport = new ReportVM
            {
                Company = _companyService.GetCompanySingleRecord(),
                AssetNovementReport = _assetMovementService.GetAssetNovementList(sortAssetsRegListVMv)
            };

            return await _generatePdf.GetPdf("Views/Report/PrintAssetMovement.cshtml", assetMovementReport);
        }

        //Merge

    }
}
