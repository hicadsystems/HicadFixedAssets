using FixedAssetCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.IServices
{
    public interface IAssetMovementService
    {
        IEnumerable<fa_Assetsreg> GetAssets();

        Task<fa_Assetsreg> GetAssetByAssetCode(string code);

        IEnumerable<fa_class> GetClassifications();

        Task<fa_class> GetClassificationByCode(string code);

        Task<bool> UpdateAssetClassification(fa_Assetsreg fa_Assetsreg);
    }
}
