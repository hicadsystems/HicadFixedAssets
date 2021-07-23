using FixedAssetCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssetCore.Core.IRepositories
{
    public interface IAssetClass:IRepository<fa_class>
    {
        Task<fa_class> GetClassByCode(string code);
    }
}
