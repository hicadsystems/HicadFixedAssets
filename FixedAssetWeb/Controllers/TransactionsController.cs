using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.Controllers
{
    public class TransactionsController : Controller
    {
        public IActionResult AssetReclassification()
        {
            return View();
        }

        public IActionResult AssetMovement()
        {
            return View();
        }
    }
}
