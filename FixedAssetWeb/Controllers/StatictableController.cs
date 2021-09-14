using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FixedAssetCore.EntityCoreVM;
using FixedAssetWeb.IServices;
using FixedAssetWeb.ViewModels.Reports;
using Microsoft.AspNetCore.Mvc;
using Wkhtmltopdf.NetCore;

namespace FixedAssetWeb.Controllers
{
    public class StatictableController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IBusinessLineService _businessLineService;
        private readonly ICostCenterService _costCenterService;
        private readonly IAssetClassService _assetclassService;
        private readonly IAssetRegisterationService _assetRegisterationService;
        private readonly IGeneratePdf _generatePdf;

        public StatictableController(ICompanyService companyService, IBusinessLineService businessLineService, IGeneratePdf generatePdf,
            ICostCenterService costCenterService, IAssetClassService assetClassService, IAssetRegisterationService assetRegisterationService)
        {
            _companyService = companyService;
            _businessLineService = businessLineService;
            _costCenterService = costCenterService;
            _assetclassService = assetClassService;
            _assetRegisterationService = assetRegisterationService;
            _generatePdf = generatePdf;
        }
        public IActionResult Company()
        {
            return View();
        }

        public IActionResult CostCenter()
        {
            return View();
        }
        public IActionResult businessline()
        {
            return View();
        }

        public IActionResult Assetreg()
        {
            return View();
        }
        public IActionResult AssetClass()
        {
            return View();
        }

        [Route("Statictable/PrintBusinessline")]
        public async Task<IActionResult> PrintBusinessline()
        {
            var businessline = new ReportVM
            {
                Company = _companyService.GetCompanySingleRecord(),
                BusinesslinesReport = _businessLineService.Getbusinesslines()
            };
            return await _generatePdf.GetPdf("Views/Statictable/PrintBusinessline.cshtml", businessline);
        }

        [Route("Statictable/PrintCostcenter")]
        public async Task<IActionResult> PrintCostcenter()
        {
            var costcenter = new ReportVM
            {
                Company = _companyService.GetCompanySingleRecord(),
                CostcenterReport = _costCenterService.GetCostCenters()
            };
            return await _generatePdf.GetPdf("Views/Statictable/PrintCostcenter.cshtml", costcenter);
        }

        [Route("Statictable/PrintAssetclass")]
        public async Task<IActionResult> PrintAssetclass()
        {
            var assetclass = new ReportVM
            {
                Company = _companyService.GetCompanySingleRecord(),
                AssetclassReport = _assetclassService.GetClass()
            };
            return await _generatePdf.GetPdf("Views/Statictable/PrintAssetclass.cshtml", assetclass);
        }

        [Route("Statictable/PrintAssetreg/")]
        public async Task<IActionResult> PrintAssetreg(SortAssetsRegListVM sortAssetsList)
        {
            //var sortAssetsRegListVMv = new SortAssetsRegListVM()
            //{
            //    classCode = classCode,
            //    classDept = classDept,
            //    startDate = startDate,
            //    endDate = endDate
            //};


            var assetreg = new ReportVM
            {
                Company = _companyService.GetCompanySingleRecord(),
                GetAssetRegReport = _assetRegisterationService.SortAssetRegList(sortAssetsList)
            };
            return await _generatePdf.GetPdf("Views/Statictable/PrintAssetreg.cshtml", assetreg);
        }
    }
}