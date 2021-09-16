using FixedAssetCore.Core.IRepositories;
using FixedAssetCore.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssetCore.Core.Data
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IUserRoleRepository UserRoles { get; }
        IMenuRepository Menus { get; }
        IRoleMenuRepository RoleMenus { get; }
        IMenuGroupRepository MenuGroups { get; }
        ICompany company { get; }
        ICostCenterRepository cost { get; }
        IBusinessLine bus { get; }
        IAssetRegistration reg { get; }
        IAssetClass assetClass { get; }
        IAccountChart accountChart { get; }
        IAssetReclassification assetReclassification { get; }
        IAssetMovementRepository assetMovementRepository { get; }
        IDepreciation depreciation { get; }

        Task<bool> Done();

        //int Complete();
    }
}
