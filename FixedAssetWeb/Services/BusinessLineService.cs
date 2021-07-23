using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.Models;
using FixedAssetWeb.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FixedAssetWeb.Services
{
    public class BusinessLineService : IBusinessLineService
    {
        private readonly IUnitOfWork unitOfWork;
        public BusinessLineService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork= unitOfWork;
        }
        public async Task<bool> Addbusinessline(nac_businessline model)
        {
            unitOfWork.bus.Create(model);
            return await unitOfWork.Done();
        }

        public nac_businessline checkbusinessByDesc(string desc)
        {
            return unitOfWork.bus.checkBusinessByDesc(desc);
        }

        public Task<nac_businessline> GetbusinesslineByCode(string code)
        {
            return unitOfWork.bus.GetBusinessLineByCode(x => x.Code == code);
        }

        public Task<nac_businessline> GetbusinesslineByID(int id)
        {
            return unitOfWork.bus.Find(id);
        }

        public IEnumerable<nac_businessline> Getbusinesslines()
        {
            return unitOfWork.bus.All();
        }

        public List<businessLineView> GetBusinessLineViewsForReport()
        {
            return unitOfWork.bus.GetBusinessLineRecordForReport();
        }

        public void Removebusinessline(nac_businessline model)
        {
            unitOfWork.bus.Remove(model);
            unitOfWork.Done();
        }

        public async Task<bool> Updatebusinessline(nac_businessline model)
        {
            unitOfWork.bus.Update(model);
            return await unitOfWork.Done();
        }

    }
}
