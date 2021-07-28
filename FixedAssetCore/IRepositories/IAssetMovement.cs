using FixedAssetCore.Core.Entities;
using FixedAssetCore.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssetCore.IRepositories
{
    public interface IAssetMovement : IRepository<fa_Assetsreg>
    {
        Task<fa_Assetsreg> GetAllAssetsRegistered();

        Task<fa_Assetsreg> GetAssetByCode(string code);
        Task<bool> UpdateAsset(fa_Assetsreg fa_Assetsreg);
    }
}
