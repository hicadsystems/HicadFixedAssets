using FixedAssetCore.Core.Entities;
using FixedAssetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssetCore.Core.IRepositories
{
    public interface IBusinessLine : IRepository<nac_businessline>
    {
        Task<nac_businessline> GetBusinessLineByCode(Expression<Func<nac_businessline, bool>> predicate);
        nac_businessline checkBusinessByDesc(string desc);
        List<businessLineView> GetBusinessLineRecordForReport();

    }
}
