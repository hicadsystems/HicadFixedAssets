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
    [Route("api/AssetClass")]
    [ApiController]
    public class AssetClassController : ControllerBase
    {
        private readonly IAssetClassService service;
        public AssetClassController(IAssetClassService service)
        {
            this.service = service;
        }
        [Route("getAllclasss")]
        [HttpGet]
        public IEnumerable<fa_class> Get()
        {
            return service.GetClass();
        }

        // GET: api/class
        [Route("getclassByCode/{id}")]
        [HttpGet]
        public IActionResult GetclassByCode(string id)
        {
            var balsheet = service.GetClassByCode(id).Result;

            if (balsheet == null)
            {
                return Ok(new { responseCode = 404, responseDescription = "Class Code does not Exist" });
            }
            return Ok(new { responseCode = 200, responseDescription = "Class Code Exist", Data = balsheet });
        }

        // GET: api/class/5
        [Route("Getl")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/class
        [Route("createclass")]
        [HttpPost]
        public IActionResult createclass([FromBody] fa_class value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.classcode))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply class Code" });
                }
                if (service.GetClassByCode(value.classcode.Trim()).Result != null)
                {
                    return Ok(new { responseCode = 400, responseDescription = "Class Code already Exist" });
                }
                // value.datecreated = DateTime.Now;
                service.AddClass(value);

                return Ok(new { responseCode = 200, responseDescription = "Created Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

        //api/class/RemoveBalsheet/7
        [Route("removeclass/{id:int}")]
        [HttpGet]
        public IActionResult Remove(string id)
        {
            var balsheet = service.GetClassByCode(id).Result;
            if (balsheet == null) return NotFound();

            service.RemoveClass(balsheet);
            return Ok(new { responseCode = 200, responseDescription = "Deleted Successful" });
        }


        // PUT: api/class/5
        [Route("updateclass")]
        [HttpPut]
        public IActionResult Put([FromBody] fa_class value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.classcode))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply class Code" });
                }

                var getbal = service.GetClassByCode(value.classcode.Trim()).Result;
                getbal.classdesc = value.classdesc;
                getbal.Deprmethod = value.Deprmethod;
                getbal.Deprrate = value.Deprrate;
                getbal.Led_accum_depr_code = value.Led_accum_depr_code;
                getbal.Led_cost_code = value.Led_cost_code;
                getbal.Led_exp_code = value.Led_exp_code;
                getbal.rank = value.rank;

                service.UpdateClass(getbal);
                return Ok(new { responseCode = 200, responseDescription = "Updated Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

    }
}