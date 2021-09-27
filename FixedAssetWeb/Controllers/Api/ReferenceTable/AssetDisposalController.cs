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
            var assetsDispList = service.AssetDisposalList(sortAssetsRegListVM);

            var assetsAvailable = assetsDispList.Count();

            if (assetsAvailable == 0)
            {
                return Ok(new { responseCode = 404, responseDescription = $"Asset with Class code { sortAssetsRegListVM.startDate } does not Exist" });
            }

            return Ok(new { responseCode = 200, responseDescription = $"{ assetsAvailable } Asset Register(s) Found", Data = assetsDispList });
        }

        // GET: api/AssetDisposal/assetDisposalAction/{assetCode}/{amount}
        [Route("assetDisposalAction/{assetCode}/{amount}")]
        [HttpGet]
        public IActionResult AssetDisposalAction(string assetCode, decimal amount)
        {
            if (string.IsNullOrEmpty(assetCode.Trim()))
            {
                return Ok(new { responseCode = 404, responseDescription = $"Please supply avalid code, Asset with Asset code { assetCode } does not Exist" });
            }

            if (amount == decimal.Zero)
            {
                return Ok(new { responseCode = 404, responseDescription = $"Please supply a valid Asset Amount, { amount } is Invalid" });
            }

            string response = service.DisposeAssetsAction(assetCode, amount);

            return Ok(new { responseCode = 200, responseDescription = response } );
        }
    }
}
