using FixedAssetCore.Core.Entities;
using FixedAssetCore.EntityCoreVM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssetCore.Core.IRepositories
{
    public interface IAssetRegistration:IRepository<fa_Assetsreg>
    {
        Task<fa_Assetsreg> getAssetRegByCode(string code);

        IEnumerable<AssetRegListVM> GetAllAssetRegisters();
    }
}
