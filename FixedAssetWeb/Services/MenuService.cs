using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetWeb.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.Services
{
    public class MenuService:IMenuService
    {
        private readonly IUnitOfWork unitOfWork;
        public MenuService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<fa_Menu> GetMenus()
        {
            return unitOfWork.Menus.All();
        }

        public IEnumerable<fa_Menu> GetActiveMenus()
        {
            return unitOfWork.Menus.GetByExpression(x => x.IsActive);
        }

        public async Task<bool> AddMenu(fa_Menu menu)
        {
            unitOfWork.Menus.Create(menu);
            return await unitOfWork.Done();
        }

        public async Task<fa_Menu> GetMenuById(int id)
        {
            return await unitOfWork.Menus.Find(id);
        }

        public fa_Menu GetMenuByCode(string code)
        {
            return unitOfWork.Menus.GetByExpression(x => x.Code == code).FirstOrDefault();
        }

        public async Task<bool> UpdateMenu(fa_Menu menu)
        {
            unitOfWork.Menus.Update(menu);
            return await unitOfWork.Done();
        }
    }
}
