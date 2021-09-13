using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.EntityCoreVM;
using FixedAssetWeb.IServices;
using FixedAssetWeb.ViewModels.AssetMovementVM;
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

        // GET: api/AssetRegisteration/getAssetsregByCode/assetCode
        [Route("getAssetsregByCode/{assetCode}")]
        [HttpGet]
        public IActionResult GetCostCenterByCode(string assetCode)
        {
            var balsheet =  service.GetAssetRegByCode(assetCode.Trim()).Result;

            if (balsheet == null)
            {
                return Ok(new { responseCode = 404, responseDescription = "Asset Registeration code does not Exist" });
            }

            return Ok(new { responseCode = 200, responseDescription = "Asset Registeration Code Exist", Data = balsheet });
        }

        // GET: api/AssetRegisteration/getAssetsregByClasscode/classCode
        [Route("getAssetsregByclassCode/{classCode}")]
        [HttpGet]
        public IActionResult GetAssetsregByclassCode(string classCode)
        {
            if (string.IsNullOrEmpty(classCode))
            {
                return Ok(new { responseCode = 404, responseDescription = "Please provide a valid class code"});
            }

            var assetsRegList = service.GetAssetRegByClasscode(classCode.Trim());

            var assetsAvailable = assetsRegList.Count();

            if (assetsAvailable == 0)
            {
                return Ok(new { responseCode = 404, responseDescription = $"Asset with Class code { classCode } does not Exist" });
            }

            return Ok(new { responseCode = 200, responseDescription = $"{ assetsAvailable } Asset Register(s) Found", Data = assetsRegList });
        }

        // GET: api/AssetRegisteration/getAssetsregByDept/Dept
        [Route("getAssetsregByDept/{dept}")]
        [HttpGet]
        public IActionResult GetAssetsregByDept(string dept)
        {
            if (string.IsNullOrEmpty(dept))
            {
                return Ok(new { responseCode = 404, responseDescription = "Please provide a valid department code" });
            }

            var assetsRegList = service.GetAssetRegByDept(dept.Trim());

            var assetsAvailable = assetsRegList.Count();

            if (assetsAvailable == 0 )
            {
                return Ok(new { responseCode = 404, responseDescription = $"Asset with Department code { dept } does not Exist" });
            }

            return Ok(new { responseCode = 200, responseDescription = $"{ assetsAvailable } Asset Register(s) Found", Data = assetsRegList });
        }

        // GET: api/CostCenter/5
        [Route("Getl")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AssetRegisteration/createAssetsreg
        [Route("createAssetsreg")]
        [HttpPost]
        public IActionResult createAssetRegister([FromBody] fa_Assetsreg value)
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

        //api/AssetRegisteration/RemoveAssetsreg/id
        [Route("RemoveAssetsreg/{id:int}")]
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var balsheet = service.GetAssetRegById(id).Result;
            if (balsheet == null) return NotFound();

            service.RemoveAssetReg(balsheet);
            return Ok(new { responseCode = 200, responseDescription = "Deleted Successful" });
        }


        // PUT: api/AssetRegisteration/updateAssetsreg/id
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


        // PUT: api/AssetRegisteration/assetrevaluation/id
        [Route("assetrevaluation")]
        [HttpPut]
        public IActionResult Put([FromBody] fa_AssetRegVM value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.assetCode))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply Asset registeration Code" });
                }

                string response = service.AssetRegEval(value);
                
                return Ok(new { responseCode = 200, responseDescription = "Updated Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

    }
}