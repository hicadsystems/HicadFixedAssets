using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetWeb.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.Services
{
    public class CompanyService : ICompanyService
    {
        private IUnitOfWork unitOfWork;
        public CompanyService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> AddCompany(nac_company bl_sheet)
        {
            unitOfWork.company.Create(bl_sheet);
            return await unitOfWork.Done();
        }

        public IEnumerable<nac_company> GetCompany()
        {
            return unitOfWork.company.All();
        }

        public Task<nac_company> GetCompanyByCode(string bcode)
        {
            return unitOfWork.company.GetCompanyByCode(x=>x.comp_code==bcode);
        }

        public Task<nac_company> GetCompanyById(int id)
        {
            return unitOfWork.company.Find(id);
        }

        public nac_company GetCompanySingleRecord()
        {
            return unitOfWork.company.GetCompanyDetails();
        }

        public Tuple<string, string> ProcessingMonthAndYear()
        {
            var result = unitOfWork.company.GetProcessingMonthAndYear();
            string month = result.Item1;
            string year = result.Item2;
            return Tuple.Create(month, year);
        }

        public void RemoveCompany(nac_company bl_sheet)
        {
            unitOfWork.company.Remove(bl_sheet);
            unitOfWork.Done();
        }

        public async Task<bool> UpdateCompany(nac_company bl_sheet)
        {
            unitOfWork.company.Update(bl_sheet);
            return await unitOfWork.Done();
        }
    }
}
