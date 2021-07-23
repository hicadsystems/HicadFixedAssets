using FixedAssetCore.Core.Entities;
using FixedAssetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.IServices
{
    public interface IBusinessLineService
    {
        IEnumerable<nac_businessline> Getbusinesslines();
        List<businessLineView> GetBusinessLineViewsForReport();
        Task<nac_businessline> GetbusinesslineByCode(string code);
        Task<nac_businessline> GetbusinesslineByID(int id);
        Task<bool> Addbusinessline(nac_businessline model);
        Task<bool> Updatebusinessline(nac_businessline model);
        void Removebusinessline(nac_businessline model);
        nac_businessline checkbusinessByDesc(string desc);
    }
}
