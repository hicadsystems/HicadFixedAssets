using FixedAssetCore.Core.Entities;
using FixedAssetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssetCore.Core.IRepositories
{
    public interface ICostCenterRepository : IRepository<nac_costcenters>
    {
        Task<nac_costcenters> GetCostCenterByCode(Expression<Func<nac_costcenters, bool>> predicate);
        nac_costcenters GetCostCenterByDesc(string desc);
        List<CostCenterView> GetCostCenterForReport();
    }
}
