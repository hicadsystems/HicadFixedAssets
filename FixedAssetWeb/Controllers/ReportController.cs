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
        public ReportController(ICompanyService companyService, IGeneratePdf generatePdf, IGenerateDepreciationService generateDepreciation)
        {
            _companyService = companyService;
            _generatePdf = generatePdf;
            _generateDepreciation = generateDepreciation;
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

    }
}
