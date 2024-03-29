﻿using FixedAssetCore.Core.Entities;
using FixedAssetCore.EntityCoreVM;
using FixedAssetWeb.IServices;
using FixedAssetWeb.ViewModels.AssetMovementVM;
using Microsoft.AspNetCore.Http;
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
        private readonly IAssetMovementService assetMovementService;
        public AssetMovementController(IAssetMovementService assetMovementService)
        {
            this.assetMovementService = assetMovementService;
        }

        // GET : /api/AssetMovement/getAllAssets
        [Route("getAllAssets")]
        [HttpGet]
        public IEnumerable<fa_Assetsreg> GetAllAssets()
        {
            return assetMovementService.GetAllAssets();
        }

        // GET : /api/AssetMovement/getAllCostCenters
        [Route("getAllCostCenters")]
        [HttpGet]
        public IEnumerable<nac_costcenters> GetAllClassifications()
        {
            return assetMovementService.GetAllCostCenters();
        }

        // GET : /api/AssetMovement/getUnitDescByAssetCode/1
        [Route("getUnitDescByAssetCode/{assetCode}")]
        [HttpGet]
        public IActionResult GetUnitDescByAssetCode(string assetCode)
        {
            var assetInDb = assetMovementService.GetCenterDescriptionWithAssetCode(assetCode);

            if (assetInDb == null)
            {
                return Ok(new { responseCode = 404, responseDescription = "Asset Code does not Exist" });
            }
            return Ok(new { responseCode = 200, responseDescription = "Asset Code Exist", Data = assetInDb });
        }

        // PUT: /api/AssetMovement/updateAssetUnitCode/
        [Route("updateAssetUnitCode/")]
        [HttpPut]
        public IActionResult UpdateAssetClassCode([FromBody] fa_AssetRegVM fa_assetRegVm)
        {
            try
            {
                if (string.IsNullOrEmpty(fa_assetRegVm.assetCode) || string.IsNullOrEmpty(fa_assetRegVm.newUnitCode))
                {
                    return Ok(new { responseCode = 500, responseDescription = $"Kindly Supply a valid Asset Code and Unit Code!! Either {fa_assetRegVm.assetCode} Or {fa_assetRegVm.newLoc} Is not Available" });
                }

                string user = User.Identity.Name;
                fa_assetRegVm.userId = user;

                assetMovementService.UpdateAssetDepartment(fa_assetRegVm);
            }
            catch (Exception e)
            {
                return Ok(new { responseCode = 500, responseDescription = "Failed", Data = e.StackTrace });
            }

            return Ok(new { responseCode = 200, responseDescription = "Updated Successfully" });
        }

        // GET: api/GetAssetMovementList/sortAssetMovement
        [Route("sortAssetMovement/")]
        [HttpPost]
        public IActionResult GetAssetNovementList([FromBody] SortAssetsRegListVM sortAssetsRegListVM)
        {
            if (string.IsNullOrEmpty(sortAssetsRegListVM.classDept) && sortAssetsRegListVM.startDate == null && sortAssetsRegListVM.endDate == null)
            {
                return Ok(new { responseCode = 404, responseDescription = "Please provide a valid sort parameter" });
            }

            var assetsRegList = assetMovementService.GetAssetNovementList(sortAssetsRegListVM);
    
            var assetsAvailable = assetsRegList.Count();

            if (assetsAvailable == 0)
            {
                return Ok(new { responseCode = 404, responseDescription = $"Asset between { sortAssetsRegListVM.startDate } and { sortAssetsRegListVM.endDate } does not Exist" });
            }

            return Ok(new { responseCode = 200, responseDescription = $"{ assetsAvailable } Asset Register(s) Found", Data = assetsRegList });
        }
    }
}
