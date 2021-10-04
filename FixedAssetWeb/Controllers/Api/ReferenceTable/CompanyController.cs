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
    [Route("api/Company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService service;
        public CompanyController(ICompanyService service)
        {
            this.service = service;
        }

        //api/Company/getAllCompany
        [Route("getAllCompany")]
        [HttpGet]
        public IEnumerable<nac_company> Get()
        {
            return service.GetCompany();
        }

        //api/Company/createCompany
        [Route("createCompany")]
        [HttpPost]
        public IActionResult createCompany([FromBody] nac_company value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.comp_code))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply company Code" });
                }
                if (service.GetCompanyByCode(value.comp_code.Trim()).Result != null)
                {
                    return Ok(new { responseCode = 400, responseDescription = "company Code already Exist" });
                }

                value.datecreated = DateTime.Now;
                value.createdby = User.Identity.Name;
                service.AddCompany(value);

                return Ok(new { responseCode = 200, responseDescription = "Created Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed" });
            }
        }

        //api/Company/RemoveCompany/7
        [Route("RemoveCompany/{id:int}")]
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var balsheet = service.GetCompanyById(id).Result;
            if (balsheet == null) return NotFound();

            service.RemoveCompany(balsheet);
            return Ok(new { responseCode = 200, responseDescription = "Deleted Successful" });
        }

        //api/Company/GetCompanyMonthAndYear
        [Route("GetCompanyMonthAndYear")]
        [HttpGet]
        public IActionResult GetCompanyMonthAndYear()
        {
            var result = service.ProcessingMonthAndYear();
            string month = result.Item1;
            string year = result.Item2;
            return Ok(new { responseCode = 200, Data = new { month, year } });
        }


        // PUT: api/BalanceSheet/5
        [Route("updateCompany")]
        [HttpPut]
        public IActionResult Put([FromBody] nac_company value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.comp_code))
                {
                    return Ok(new { responseCode = 500, responseDescription = "Kindly Supply company Code" });
                }
                var getbal = service.GetCompanyByCode(value.comp_code.Trim()).Result;

                getbal.comp_code = value.comp_code;
                getbal.comp_name = value.comp_name;
                getbal.Address = value.Address;
                getbal.Processyear = value.Processyear;
                getbal.processmonth = value.processmonth;
                getbal.box = value.box;
                getbal.createdby = value.createdby;
                getbal.datecreated = value.datecreated;
                getbal.email = value.email;
                getbal.hrlink = value.hrlink;
                getbal.lg = value.lg;
                getbal.mthly_tax = value.mthly_tax;
                getbal.retireage = value.retireage;
                getbal.runtype = value.runtype;
                getbal.salaryscale = value.salaryscale;
                getbal.serveraddr = value.serveraddr;
                getbal.serverport = value.serverport;
                getbal.state = value.state;
                getbal.tel = value.tel;
                getbal.town = value.town;
                getbal.MinBookVal = value.MinBookVal;


                service.UpdateCompany(getbal);

                return Ok(new { responseCode = 200, responseDescription = "Updated Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed", message = ex });
            }
        }

    }
}