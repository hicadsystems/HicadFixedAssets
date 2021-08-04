using FixedAssetCore.Core.Entities;
using FixedAssetWeb.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.Controllers.Api.Transaction
{
    [Route("api/AssetMovement")]
    [ApiController]
    public class AssetMovementController : ControllerBase
    {
        private readonly IAssetMovementService assetMovementService;
        public AssetMovementController(IAssetMovementService assetMovementService)
        {
            this.assetMovementService = assetMovementService;
        }

        // GET : /api/AssetMovement/getAllAssets
        [Route("getAllAssets")]
        [HttpGet]
        public IEnumerable<fa_Assetsreg> GetAllAssets()
        {
            return assetMovementService.GetAllAssets();
        }

        // GET : /api/AssetMovement/getAllCostCenters
        [Route("getAllCostCenters")]
        [HttpGet]
        public IEnumerable<nac_costcenters> GetAllClassifications()
        {
            return assetMovementService.GetAllCostCenters();
        }

        // GET : /api/AssetMovement/getUnitDescByAssetCode/1
        [Route("getUnitDescByAssetCode/{assetCode}")]
        [HttpGet]
        public IActionResult GetUnitDescByAssetCode(string assetCode)
        {
            var assetInDb = assetMovementService.GetCenterDescriptionWithAssetCode(assetCode);

            if (assetInDb == null)
            {
                return Ok(new { responseCode = 404, responseDescription = "Asset Code does not Exist" });
            }
            return Ok(new { responseCode = 200, responseDescription = "Asset Code Exist", Data = assetInDb });
        }
    }
}
