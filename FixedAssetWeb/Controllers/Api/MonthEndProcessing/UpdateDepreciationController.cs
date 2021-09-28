using FixedAssetWeb.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.Controllers.Api.MonthEndProcessing
{
    [Route("api/UpdateDepreciation")]
    [ApiController]
    public class UpdateDepreciationController : ControllerBase
    {
        private readonly IGenerateDepreciationService generateDepreciationService;

        public UpdateDepreciationController(IGenerateDepreciationService generateDepreciationService)
        {
            this.generateDepreciationService = generateDepreciationService;
        }

        // GET: api/UpdateDepreciation/UpdateAssets/{month}/{year}
        [Route("UpdateAssets/{month}/{year}")]
        [HttpGet]
        public IActionResult UpdateAssetsAction(string month, string year)
        {
            if (string.IsNullOrEmpty(month) && string.IsNullOrEmpty(year))
            {
                return Ok(new { responseCode = 404, responseDescription = $"Date Range can not be null" });
            }

            if (Convert.ToInt32(month) > 2 && Convert.ToInt32(month) <= 0 && Convert.ToInt32(year) > 4 && Convert.ToInt32(year) <= 0)
            {
                return Ok(new { responseCode = 404, responseDescription = $"Please supply avalid Date Range!!" });
            }

            string response = generateDepreciationService.UpdateDepreciations(month, year);

            return Ok(new { responseCode = 200, responseDescription = response });
        }
    }
}
