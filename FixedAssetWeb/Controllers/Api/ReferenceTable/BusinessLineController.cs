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
    [Route("api/BusinessLine")]
    [ApiController]
    public class BusinessLineController : ControllerBase
    {
        private readonly IBusinessLineService businessLineService;
        public BusinessLineController(IBusinessLineService businessLineService)
        {

            this.businessLineService = businessLineService;
        }
        //api/BusinessLine/getAllBusinessLine
        [Route("getAllBusinessLine")]
        [HttpGet]
        public IEnumerable<nac_businessline> Get()
        {
            return businessLineService.Getbusinesslines();
        }

        ///api/BusinessLine/getBusinessLineByCode
        [Route("getBusinessLineByCode/{id}")]
        [HttpGet]
        public IActionResult GetCostCenterByCode(string id)
        {
            var balsheet = businessLineService.GetbusinesslineByCode(id);

            if (balsheet == null)
            {
                return Ok(new { responseCode = 404, responseDescription = "businessline does not Exist" });
            }
            return Ok(new { responseCode = 200, responseDescription = "businessline Code Exist", Data = balsheet });
        }

        // GET: api/CostCenter/5
        [Route("Getl")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //api/BusinessLine/createBusinessLine
        [Route("createBusinessLine")]
        [HttpPost]
        public IActionResult createCostCenter([FromBody] nac_businessline value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.Code))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply businessline Code" });
                }
                if (businessLineService.GetbusinesslineByCode(value.Code.Trim()).Result != null)
                {
                    return Ok(new { responseCode = 400, responseDescription = "Businessline Code already Exist" });
                }
                value.datecreated = DateTime.Now;
                value.createdby = User.Identity.Name;
                value.startDate = DateTime.Now;
                businessLineService.Addbusinessline(value);

                return Ok(new { responseCode = 200, responseDescription = "Created Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

        //api/BusinessLine/RemoveBusinessLine
        [Route("RemoveBusinessLine/{id:int}")]
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var balsheet = businessLineService.GetbusinesslineByID(id).Result;
            if (balsheet == null) return NotFound();

            businessLineService.Removebusinessline(balsheet);
            return Ok(new { responseCode = 200, responseDescription = "Deleted Successful" });
        }


        //api/BusinessLine/updateBusinessLine
        [Route("updateBusinessLine")]
        [HttpPut]
        public IActionResult Put([FromBody] nac_businessline value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.Code))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply business line Code" });
                }
                var getbal = businessLineService.GetbusinesslineByCode(value.Code.Trim()).Result;
                getbal.Description = value.Description;
                getbal.startDate = value.startDate;
                getbal.processingMonth = value.processingMonth;
                getbal.processingYear = value.processingYear;
                getbal.interestacct = value.interestacct;
                getbal.interestacct = value.interestacct;
                getbal.incomeacct = value.incomeacct;
                getbal.fundacct = value.fundacct;
                getbal.trusteeacct = value.trusteeacct;
                getbal.datecreated = DateTime.Now;
                getbal.createdby = User.Identity.Name;
                businessLineService.Updatebusinessline(getbal);
                return Ok(new { responseCode = 200, responseDescription = "Updated Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

    }
}