using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.Controllers
{
    public class MonthEndProcessingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GenerateDepreciation()
        {
            return View();
        }
    }
}
