using FixedAssetCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.IServices
{
    public interface IAssetClassService
    {
        IEnumerable<fa_class> GetClass();
        void RemoveClass(fa_class bl_sheet);
        Task<fa_class> GetClassById(int id);
        Task<bool> AddClass(fa_class bl_sheet);
        Task<fa_class> GetClassByCode(string bcode);
        Task<bool> UpdateClass(fa_class bl_sheet);
    }
}
