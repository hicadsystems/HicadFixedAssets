using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.Core.IRepositories;
using FixedAssetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssetCore.Core.Repositories
{
    public class BusinessLineRepository : Repository<nac_businessline>, IBusinessLine
    {
        private readonly IAssetDbContext context;
        public BusinessLineRepository(IAssetDbContext context):base(context)
        {
            this.context = context;
        }

        public nac_businessline checkBusinessByDesc(string desc)
        {
            return context.nac_businessline.FirstOrDefault(x => x.Description == desc);
        }

        public List<businessLineView> GetBusinessLineRecordForReport()
        {
            string companyname = context.nac_company.FirstOrDefault().comp_name;
            string address = context.nac_company.FirstOrDefault().Address;


            return (from b in context.nac_businessline
                    select new businessLineView
                    {
                        companyname = companyname,
                        compaddress = address,
                        Code = b.Code,
                        createdby = b.createdby,
                        datecreated = b.datecreated,
                        Description = b.Description,
                        fundacct = b.fundacct,
                        incomeacct = b.incomeacct,
                        interestacct = b.interestacct,
                        jvno = b.jvno,
                        paymentno = b.paymentno,
                        processingMonth = b.processingMonth,
                        processingYear = b.processingYear,
                        profitacct = b.profitacct,
                        receiptno = b.receiptno,
                        startDate = b.startDate,
                        trusteeacct = b.trusteeacct
                    }).ToList();
        }

        public Task<nac_businessline> GetBusinessLineByCode(Expression<Func<nac_businessline, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
