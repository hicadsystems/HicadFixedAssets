using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FixedAssetCore.Core.Repositories
{
    public class CompanyRepository:Repository<nac_company>,ICompany
    {
        private readonly IAssetDbContext context;
        public CompanyRepository(IAssetDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<nac_company> GetCompanyByCode(Expression<Func<nac_company, bool>> predicate)
        {
            return await context.nac_company.FirstOrDefaultAsync(predicate);
        }

        public nac_company GetCompanyDetails()
        {
            return context.nac_company.FirstOrDefault();
        }

        public Tuple<string, string> GetProcessingMonthAndYear()
        {
            var company = context.nac_company.FirstOrDefault();

            string processingMonth = company.processmonth;
            string processingYear = company.Processyear;

            return Tuple.Create(processingMonth, processingYear);
        }
    }
}
