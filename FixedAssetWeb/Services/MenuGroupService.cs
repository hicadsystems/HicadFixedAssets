using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetWeb.IServices;
using System.Collections.Generic;

namespace FixedAssetWeb.Services
{
    public class MenuGroupService : IMenuGroupService
    {
        private readonly IUnitOfWork unitOfWork;
        public MenuGroupService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<fa_MenuGroup> GetMenuGroupss()
        {
            return unitOfWork.MenuGroups.All();
        }

        public IEnumerable<fa_MenuGroup> GetActiveMenuGroups()
        {
            return null;
        }
    }
}
