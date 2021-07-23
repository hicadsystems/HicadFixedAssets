using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FixedAssetCore.Core.Entities;
using FixedAssetWeb.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FixedAssetWeb.Controllers.Api.ReferenceTable
{
    [Route("api/CostCenter")]
    [ApiController]
    public class CostCenterController : ControllerBase
    {
        private readonly ICostCenterService costCenterService;
        public CostCenterController(ICostCenterService costCenterService)
        {

            this.costCenterService = costCenterService;
        }
        [Route("getAllCostCenters")]
        [HttpGet]
        public IEnumerable<nac_costcenters> Get()
        {
            return costCenterService.GetCostCenters();
        }

        // GET: api/CostCenter
        [Route("getCostCenterByCode/{id}")]
        [HttpGet]
        public IActionResult GetCostCenterByCode(string id)
        {
            var balsheet = costCenterService.GetCostCenterByCode(id).Result;

            if (balsheet == null)
            {
                return Ok(new { responseCode = 404, responseDescription = "Cost Center Code does not Exist" });
            }
            return Ok(new { responseCode = 200, responseDescription = "Cost Center Code Exist", Data = balsheet });
        }

        // GET: api/CostCenter/5
        [Route("Getl")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CostCenter
        [Route("createCostCenter")]
        [HttpPost]
        public IActionResult createCostCenter([FromBody] nac_costcenters value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.unitcode))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply Cost Center Code" });
                }
                if (costCenterService.GetCostCenterByCode(value.unitcode.Trim()).Result != null)
                {
                    return Ok(new { responseCode = 400, responseDescription = "Cost Center Code already Exist" });
                }
                // value.datecreated = DateTime.Now;
                costCenterService.AddCostCenter(value);

                return Ok(new { responseCode = 200, responseDescription = "Created Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

        //api/CostCenter/RemoveBalsheet/7
        [Route("RemoveCostCenter/{id:int}")]
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var balsheet = costCenterService.GetCostCenterById(id).Result;
            if (balsheet == null) return NotFound();

            costCenterService.RemoveCostCenter(balsheet);
            return Ok(new { responseCode = 200, responseDescription = "Deleted Successful" });
        }


        // PUT: api/CostCenter/5
        [Route("updateCostCenter")]
        [HttpPut]
        public IActionResult Put([FromBody] nac_costcenters value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.unitcode))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply Cost Center Code" });
                }
                var getbal = costCenterService.GetCostCenterByCode(value.unitcode.Trim()).Result;
                getbal.unitdesc = value.unitdesc;
                costCenterService.UpdateCostCenter(getbal);
                return Ok(new { responseCode = 200, responseDescription = "Updated Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

    }
}