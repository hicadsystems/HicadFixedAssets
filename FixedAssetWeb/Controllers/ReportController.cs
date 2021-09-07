using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.Controllers
{
    public class ReportController : Controller
    {
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

    }
}
