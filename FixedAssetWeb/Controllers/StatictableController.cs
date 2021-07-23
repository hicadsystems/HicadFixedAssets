using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FixedAssetWeb.Controllers
{
    public class StatictableController : Controller
    {
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
    }
}