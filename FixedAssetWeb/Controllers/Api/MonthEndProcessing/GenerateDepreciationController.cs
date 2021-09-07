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

    }
}
