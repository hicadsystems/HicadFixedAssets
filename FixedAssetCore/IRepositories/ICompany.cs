using FixedAssetCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssetCore.Core.IRepositories
{
    public interface ICompany:IRepository<nac_company>
    {
        Task<nac_company> GetCompanyByCode(Expression<Func<nac_company, bool>> predicate);
        nac_company GetCompanyDetails();
    }
}
