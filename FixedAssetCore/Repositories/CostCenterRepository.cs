using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.Core.IRepositories;
using FixedAssetCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssetCore.Core.Repositories
{
    public class CostCenterRepository:Repository<nac_costcenters>,ICostCenterRepository
    {
        private readonly IAssetDbContext context;
        public CostCenterRepository(IAssetDbContext context):base(context)
        {
            this.context = context;
        }

        public async Task<nac_costcenters> GetCostCenterByCode(Expression<Func<nac_costcenters, bool>> predicate)
        {
            return await context.nac_costcenters.FirstOrDefaultAsync(predicate);
        }

        public nac_costcenters GetCostCenterByDesc(string desc)
        {
            return context.nac_costcenters.FirstOrDefault(x => x.unitdesc.ToUpper() == desc.ToUpper()); 
        }

        public List<CostCenterView> GetCostCenterForReport()
        {
            string companyname = context.nac_company.FirstOrDefault().comp_name;
            string address = context.nac_company.FirstOrDefault().Address;

            return (from p in context.nac_costcenters
                    select new CostCenterView
                    {
                        companyname = companyname,
                        compaddress = address,
                        unitcode = p.unitcode,
                        unitdesc = p.unitdesc
                    }).ToList();
        }
    }
}
