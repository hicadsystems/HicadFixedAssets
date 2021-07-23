using FixedAssetCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.IServices
{
    public interface IMenuService
    {
        IEnumerable<fa_Menu> GetActiveMenus();
        IEnumerable<fa_Menu> GetMenus();
        Task<fa_Menu> GetMenuById(int id);
        Task<bool> AddMenu(fa_Menu menu);
        Task<bool> UpdateMenu(fa_Menu menu);
        fa_Menu GetMenuByCode(string code);
    }
}
