using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.Models;
using FixedAssetWeb.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.Services
{
    public class CostCenterService : ICostCenterService
    {
        private readonly IUnitOfWork unitOfWork;
        public CostCenterService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }
        public Task<nac_costcenters> GetCostCenterByCode(string balcode)
        {
            return unitOfWork.cost.GetCostCenterByCode(x => x.unitcode == balcode);

        }
        public async Task<bool> AddCostCenter(nac_costcenters balsheet)
        {
            unitOfWork.cost.Create(balsheet);
            return await unitOfWork.Done();
        }

        public IEnumerable<nac_costcenters> GetCostCenters()
        {
            return unitOfWork.cost.All();
        }


        public Task<nac_costcenters> GetCostCenterById(int id)
        {
            return unitOfWork.cost.Find(id);
        }

        public async Task<bool> UpdateCostCenter(nac_costcenters balsheet)
        {
            unitOfWork.cost.Update(balsheet);
            return await unitOfWork.Done();
        }

        public void RemoveCostCenter(nac_costcenters bl_sheet)
        {
            unitOfWork.cost.Remove(bl_sheet);
            unitOfWork.Done();
        }

        public nac_costcenters GetCostCenterByDesc(string desc)
        {
            return unitOfWork.cost.GetCostCenterByDesc(desc);
        }

        public List<CostCenterView> GetCostCenterForReport()
        {
            return unitOfWork.cost.GetCostCenterForReport();
        }
    }
}
