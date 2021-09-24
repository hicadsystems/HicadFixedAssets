using FixedAssetCore.EntityCoreVM;
using FixedAssetWeb.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.Controllers.Api.ReferenceTable
{
    [Route("api/AssetDisposal")]
    [ApiController]
    public class AssetDisposalController : ControllerBase
    {
        private readonly IAssetDisposalService service;

        public AssetDisposalController(IAssetDisposalService service)
        {

            this.service = service;
        }

        // POST: api/AssetDisposal/getDisposedAsset/
        [Route("getDisposedAsset")]
        [HttpPost]
        public IActionResult GetAssetDisposal([FromBody] SortAssetsRegListVM sortAssetsRegListVM)
        {

            //if (sortAssetsRegListVM.startDate == null && sortAssetsRegListVM.endDate == null)
            //{
            //    return Ok(new { responseCode = 404, responseDescription = "Please provide a valid sort parameter" });
            //}

            var assetsDispList = service.AssetDisposalList(sortAssetsRegListVM);

            var assetsAvailable = assetsDispList.Count();

            if (assetsAvailable == 0)
            {
                return Ok(new { responseCode = 404, responseDescription = $"Asset with Class code { sortAssetsRegListVM.startDate } does not Exist" });
            }

            return Ok(new { responseCode = 200, responseDescription = $"{ assetsAvailable } Asset Register(s) Found", Data = assetsDispList });
        }
    }
}
