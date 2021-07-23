using FixedAssetCore.Core.Entities;
using FixedAssetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.IServices
{
    public interface ICostCenterService
    {
        IEnumerable<nac_costcenters> GetCostCenters();
        List<CostCenterView> GetCostCenterForReport();
        void RemoveCostCenter(nac_costcenters bl_sheet);
        Task<nac_costcenters> GetCostCenterById(int id);
        Task<nac_costcenters> GetCostCenterByCode(string bcode);
        Task<bool> AddCostCenter(nac_costcenters bl_sheet);
        Task<bool> UpdateCostCenter(nac_costcenters bl_sheet);
        nac_costcenters GetCostCenterByDesc(string desc);
    }
}
