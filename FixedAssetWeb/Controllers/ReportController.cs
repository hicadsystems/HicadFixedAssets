using FixedAssetCore.EntityCoreVM;
using FixedAssetWeb.IServices;
using FixedAssetWeb.ViewModels.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;
using static System.Net.Mime.MediaTypeNames;

namespace FixedAssetWeb.Controllers
{
    public class ReportController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IGeneratePdf _generatePdf;
        private readonly IGenerateDepreciationService _generateDepreciation;
        private readonly IAssetMovementService _assetMovementService;
        private readonly IAssetRegisterationService _assetRegisterationService;
        private readonly IAssetDisposalService _assetDisposalService;
        public ReportController(ICompanyService companyService, IGeneratePdf generatePdf, IGenerateDepreciationService generateDepreciation, 
            IAssetMovementService assetMovementService, IAssetRegisterationService assetRegisterationService, IAssetDisposalService assetDisposalService)
        {
            _companyService = companyService;
            _generatePdf = generatePdf;
            _generateDepreciation = generateDepreciation;
            _assetMovementService = assetMovementService;
            _assetRegisterationService = assetRegisterationService;
            _assetDisposalService = assetDisposalService;
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

        public IActionResult MonthlyJournal()
        {
            return View();
        }

        public IActionResult DepreciationNote()
        {
            return View();
        }

        public IActionResult DepreciationSchedule()
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

        [Route("Report/PrintAssetDisposal/{startDate}/{endDate}")]
        public async Task<IActionResult> PrintAssetDisposal(DateTime? startDate, DateTime? endDate)
        {
            var sortAssetsRegListVMv = new SortAssetsRegListVM()
            {
                startDate = startDate,
                endDate = endDate
            };

            var assetDisposalReport = new ReportVM
            {
                Company = _companyService.GetCompanySingleRecord(),
                AssetDisposal = _assetDisposalService.AssetDisposalList(sortAssetsRegListVMv)
            };

            return await _generatePdf.GetPdf("Views/Report/PrintAssetDisposal.cshtml", assetDisposalReport);
        }

        [Route("Report/MonthlyJournalReport/{month}/{year}")]
        public async Task<IActionResult> MonthlyJournalReport(string month, string year)
        {
            if (month == null && year == null)
                return BadRequest("Date Input is Required");
            var monthlyJournalReport = new ReportVM
            {
                Company = _companyService.GetCompanySingleRecord(),
                MonthlyJournal = _generateDepreciation.SortDepreciationsByClass(month, year),
                MonthlyJournal2 = _generateDepreciation.OrderDepreciationsByClass(month, year)
            };
            return await _generatePdf.GetPdf("Views/Report/MonthlyJournalReport.cshtml", monthlyJournalReport);
        }

        [Route("Report/DepreciationNotesReport/{classCode}/{month}/{year}")]
        public async Task<IActionResult> DepreciationNotesReport(string classCode, string month, string year)
        {
            if (month == null && year == null)
                return BadRequest("Date Input is Required");
            var depreciationNoteReport = new ReportVM
            {
                Company = _companyService.GetCompanySingleRecord(),
                DepreciationNote = _generateDepreciation.DepreciationNoteService(classCode, month, year),
                DepreciationNote2 = _generateDepreciation.GetDepreciationNoteByClassService(classCode, month, year),
            };
            return await _generatePdf.GetPdf("Views/Report/DepreciationNotesReport.cshtml", depreciationNoteReport);
        }

        [Route("Report/DepreciationScheduleForClass/{classCode}")]
        public async Task<IActionResult> DepreciationScheduleForClass(string classCode)
        {
            var depreciationSheduleReport = new ReportVM
            {
                Company = _companyService.GetCompanySingleRecord(),
                DepreciationSchedule1 = _generateDepreciation.DepreciationScheduleByClass(classCode),
                DepreciationSchedule2 = _generateDepreciation.GroupDepreciationScheduleByClass(classCode)
            };

            return await _generatePdf.GetPdf("Views/Report/DepreciationScheduleForClass.cshtml", depreciationSheduleReport);
        }

        [Route("Report/DepreciationScheduleForDepartment/{dept}")]
        public async Task<IActionResult> DepreciationScheduleForDepartment(string dept)
        {
            var depreciationSheduleReport = new ReportVM
            {
                Company = _companyService.GetCompanySingleRecord(),
                DepreciationSchedule1 = _generateDepreciation.DepreciationScheduleByDept(dept),
                DepreciationSchedule2 = _generateDepreciation.GroupDepreciationScheduleByDept(dept)
            };

            return await _generatePdf.GetPdf("Views/Report/DepreciationScheduleForClass.cshtml", depreciationSheduleReport);
        }

        [Route("Report/DepreciationScheduleForBusinessline/{busline}")]
        public async Task<IActionResult> DepreciationScheduleForBusinessline(string busline)
        {
            var depreciationSheduleReport = new ReportVM
            {
                Company = _companyService.GetCompanySingleRecord(),
                DepreciationSchedule1 = _generateDepreciation.DepreciationScheduleByBusinessLine(busline),
                DepreciationSchedule2 = _generateDepreciation.GroupDepreciationScheduleByBusinessLine(busline)
            };

            return await _generatePdf.GetPdf("Views/Report/DepreciationScheduleForBusinessline.cshtml", depreciationSheduleReport);
        }
    }
}
