using FixedAssetCore.EntityCoreVM;
using FixedAssetWeb.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.Controllers.Api.MonthEndProcessing
{
    [Route("api/GenerateDepreciation")]
    [ApiController]
    public class GenerateDepreciationController : ControllerBase
    {
        private IGenerateDepreciationService generateDepreciationService;
        public GenerateDepreciationController(IGenerateDepreciationService generateDepreciation)
        {
            this.generateDepreciationService = generateDepreciation;
        }

        [Route("date")]
        [HttpPost]
        public IActionResult GenerateAssetDepreciation([FromBody]DepreciationCalulationVM depreciationCalulationVM)
        {
            var dateTime = depreciationCalulationVM.depdate;

            try
            {
                if (dateTime == null)
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply A Valid Date" });
                }
                string username = User.Identity.Name;

                generateDepreciationService.GenerateDepreciation(username, dateTime);

                return Ok(new { responseCode = 200, responseDescription = "Depreciation Generated Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed " + ex.Message });
            }
        }

        // GET: api/GenerateDepreciation/sortAssetDepreciation
        [Route("sortAssetDepreciation")]
        [HttpPost]
        public IActionResult SortAssetDepreciation([FromBody] SortAssetsRegListVM sortDepreciation)
        {
            if (sortDepreciation.startDate == null && sortDepreciation.endDate == null)
            {
                return Ok(new { responseCode = 404, responseDescription = "Please provide a valid sort parameter" });
            }

            var assetsRegList = generateDepreciationService.SortAssetsDeprecation(sortDepreciation);

            var assetsAvailable = assetsRegList.Count();

            if (assetsAvailable == 0)
            {
                return Ok(new { responseCode = 404, responseDescription = $"Asset between { sortDepreciation.startDate } and { sortDepreciation.endDate } does not Exist" });
            }

            return Ok(new { responseCode = 200, responseDescription = $"{ assetsAvailable } Asset Register(s) Found", Data = assetsRegList });
        }

        // GET: api/GenerateDepreciation/depreciationSummary/assetcode
        [Route("depreciationSummary/{assetcode}")]
        [HttpGet]
        public IActionResult DepreciationSummary(string assetcode)
        {
            if (string.IsNullOrEmpty(assetcode))
            {
                return Ok(new { responseCode = 404, responseDescription = "Please provide a valid asset" });
            }

            var assetsRegList = generateDepreciationService.DeprecationSummaryReport(assetcode.Trim());

            var assetsAvailable = assetsRegList.Count();

            if (assetsAvailable == 0)
            {
                return Ok(new { responseCode = 404, responseDescription = $"Asset with { assetcode } does not Exist" });
            }

            return Ok(new { responseCode = 200, responseDescription = $"{ assetsAvailable } Asset Register(s) Found", Data = assetsRegList });
        }
    }
}
