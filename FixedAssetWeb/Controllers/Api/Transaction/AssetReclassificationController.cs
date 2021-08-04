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
    [Route("api/AssetReclassification")]
    [ApiController]
    public class AssetReclassificationController : ControllerBase
    {
        private readonly IAssetReclassificationService service;
        public AssetReclassificationController(IAssetReclassificationService service)
        {
            this.service = service;
        }

        // GET : /api/AssetReclassification/getAllAssets
        [Route("getAllAssets")]
        [HttpGet]
        public IEnumerable<fa_Assetsreg> GetAllAssets()
        {
            return service.GetAssets();
        }

        // GET : /api/AssetReclassification/getAssetByAssetCode/1
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

        // GET : /api/AssetReclassification/getClassDescByAssetCode/1
        [Route("getClassDescByAssetCode/{assetCode}")]
        [HttpGet]
        public IActionResult GetClassDescByAssetCode(string assetCode)
        {
            var assetInDb = service.GetClassDescriptionWithAssetCode(assetCode);

            if (assetInDb == null)
            {
                return Ok(new { responseCode = 404, responseDescription = "Asset Code does not Exist" });
            }
            return Ok(new { responseCode = 200, responseDescription = "Asset Code Exist", Data = assetInDb });
        }

        // GET : /api/AssetReclassification/getAllClassifications
        [Route("getAllClassifications")]
        [HttpGet]
        public IEnumerable<fa_class> GetAllClassifications()
        {
            return service.GetClassifications();
        }

        // GET : /api/AssetReclassification/getClassificationByCode/1
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

        // PUT: /api/AssetReclassification/updateAssetClassCode/
        [Route("updateAssetClassCode/")]
        [HttpPut]
        public IActionResult UpdateAssetClassCode([FromBody]fa_AssetRegVM fa_assetRegVm)
        {
            try
            {
                if (string.IsNullOrEmpty(fa_assetRegVm.assetCode) || string.IsNullOrEmpty(fa_assetRegVm.newClassCode))
                {
                    return Ok(new { responseCode = 500, responseDescription = $"Kindly Supply a valid Asset Code and Class Code!! Either {fa_assetRegVm.assetCode} Or {fa_assetRegVm.newClassCode} Is not Available" });
                }

                service.UpdateAssetClassification(fa_assetRegVm);
            }
            catch (Exception e)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed", Data = e.StackTrace });
            }

            return Ok(new { responseCode = 200, responseDescription = "Updated Successfully" });
        }
    }
}
