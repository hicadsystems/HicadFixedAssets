using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.EntityCoreVM;
using FixedAssetWeb.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FixedAssetWeb.Controllers.Api.ReferenceTable
{
    [Route("api/AssetRegisteration")]
    [ApiController]
    public class AssetRegisterationController : ControllerBase
    {
        private readonly IAssetRegisterationService service;
        public AssetRegisterationController(IAssetRegisterationService service)
        {

            this.service = service;
        }

        [Route("getAllAssetsreg")]
        [HttpGet]
        public IEnumerable<fa_Assetsreg> Get()
        {
            return service.GetAssetReg();
        }

        [Route("getAllAssets")]
        [HttpGet]
        public IEnumerable<AssetRegListVM> GetAllAssets()
        {
            return service.GetAllAssetReg();
        }

        // GET: api/CostCenter
        [Route("getAssetsregByCode/{id}")]
        [HttpGet]
        public IActionResult GetCostCenterByCode(string id)
        {
            var balsheet =  service.GetAssetRegByCode(id);

            if (balsheet == null)
            {
                return Ok(new { responseCode = 404, responseDescription = "Asset Registeration code does not Exist" });
            }
            return Ok(new { responseCode = 200, responseDescription = "Asset Registeration Code Exist", Data = balsheet });
        }

        // GET: api/CostCenter/5
        [Route("Getl")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CostCenter
        [Route("createAssetsreg")]
        [HttpPost]
        public IActionResult createCostCenter([FromBody] fa_Assetsreg value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.assetCode))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply Asset registeration Code" });
                }
                if (service.GetAssetRegByCode(value.assetCode.Trim()).Result != null)
                {
                    return Ok(new { responseCode = 400, responseDescription = "Asset registeration Code already Exist" });
                }
                service.AddAssetReg(value);
            

                return Ok(new { responseCode = 200, responseDescription = "Created Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

        //api/CostCenter/RemoveBalsheet/7
        [Route("RemoveAssetsreg/{id:int}")]
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var balsheet = service.GetAssetRegById(id).Result;
            if (balsheet == null) return NotFound();

            service.RemoveAssetReg(balsheet);
            return Ok(new { responseCode = 200, responseDescription = "Deleted Successful" });
        }


        // PUT: api/CostCenter/5
        [Route("updateAssetsreg")]
        [HttpPut]
        public IActionResult Put([FromBody] fa_Assetsreg value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.assetCode))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply Asset registeration Code" });
                }
                var getbal =service.GetAssetRegByCode(value.assetCode.Trim()).Result;
                getbal.assetDesc = value.assetDesc;
                getbal.Accum_depre = value.Accum_depre;
                getbal.Busline = value.Busline;
                getbal.Class = value.Class;
                getbal.depr_rate = value.depr_rate;
                getbal.Dept = value.Dept;
                getbal.Dispdate = value.Dispdate;
                getbal.Dispval = value.Dispval;
                getbal.Insurdate = value.Insurdate;
                getbal.Insuredval = value.Insuredval;
                getbal.movedate = value.movedate;
                getbal.Purchdate = value.Purchdate;
                getbal.Purchval = value.Purchval;
                getbal.Reclassdate = value.Reclassdate;
                getbal.Revaldate = value.Revaldate;
                getbal.Revalval = value.Revalval;
                getbal.year_depr = value.year_depr;
                service.UpdateAssetReg(getbal);
                return Ok(new { responseCode = 200, responseDescription = "Updated Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

    }
}