using FixedAssetCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.IServices
{
    public interface ICompanyService
    {
        IEnumerable<nac_company> GetCompany();
        nac_company GetCompanySingleRecord();
        void RemoveCompany(nac_company bl_sheet);
        Task<nac_company> GetCompanyById(int id);
        Task<bool> AddCompany(nac_company bl_sheet);
        Task<nac_company> GetCompanyByCode(string bcode);
        Task<bool> UpdateCompany(nac_company bl_sheet);
        Tuple<string, string> ProcessingMonthAndYear();
    }
}
