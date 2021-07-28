using FixedAssetCore.Core.Entities;
using FixedAssetWeb.IServices;
using FixedAssetWeb.ViewModels.AssetMovementVM;
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
        private readonly IAssetMovementService service;
        public AssetMovementController(IAssetMovementService service)
        {
            this.service = service;
        }

        // GET : api/AssetMovement/getAllAssets
        [Route("getAllAssets")]
        [HttpGet]
        public IEnumerable<fa_Assetsreg> GetAllAssets()
        {
            return service.GetAssets();
        }

        // GET : api/AssetMovement/getAssetByAssetCode/1
        [Route("getAssetByAssetCode/{id}")]
        [HttpGet]
        public IActionResult GetAssetByAssetCode(string id)
        {
            var assetInDb = service.GetAssetByAssetCode(id);

            if (assetInDb == null)
            {
                return Ok(new { responseCode = 404, responseDescription = "Asset Code does not Exist" });
            }
            return Ok(new { responseCode = 200, responseDescription = "Asset Code Exist", Data = assetInDb });
        }

        // GET : api/AssetMovement/getAllClassifications
        [Route("getAllClassifications")]
        [HttpGet]
        public IEnumerable<fa_class> GetAllClassifications()
        {
            return service.GetClassifications();
        }

        // GET : api/AssetMovement/getClassificationByCode/1
        [Route("getClassificationByCode/{id}")]
        [HttpGet]
        public IActionResult GetClassificationByClassCode(string id)
        {
            var classInDb = service.GetClassificationByCode(id);

            if (classInDb == null)
            {
                return Ok(new { responseCode = 404, responseDescription = "Class Code does not Exist" });
            }
            return Ok(new { responseCode = 200, responseDescription = "Class Code Exist", Data = classInDb });
        }

        // PUT: api/AssetMovement/updateAssetClassCode/88/1
        [Route("updateAssetClassCode/")]
        [HttpPut]
        public IActionResult UpdateAssetCode([FromBody]fa_AssetRegVM fa_AssetRegVm)
        {
            try
            {
                if (string.IsNullOrEmpty(fa_AssetRegVm.assetCode) || string.IsNullOrEmpty(fa_AssetRegVm.classCode))
                {
                    return Ok(new { responseCode = 500, responseDescription = $"Kindly Supply a valid Asset Code and Class Code!! Either {fa_AssetRegVm.assetCode} Or {fa_AssetRegVm.classCode} Is not Available" });
                }

                var assetInDb = service.GetAssetByAssetCode(fa_AssetRegVm.assetCode.Trim()).Result;
                var newClassCode = fa_AssetRegVm.classCode.Trim();

                if (assetInDb == null)
                {
                    return Ok(new { responseCode = 404, responseDescription = "Asset Code does not Exist" });
                }

                assetInDb.Class = newClassCode;

                service.UpdateAssetClassification(assetInDb);

                return Ok(new { responseCode = 200, responseDescription = "Updated Successfully" });
            }
            catch (Exception)
            {

                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }
    }
}
