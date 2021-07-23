using FixedAssetCore.Core.IRepositories;
using FixedAssetCore.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssetCore.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAssetDbContext context;
        public UnitOfWork(IAssetDbContext context)
        {
            this.context = context;

            Users = new UserRepository(context);
            Menus = new MenuRepository(context);
            RoleMenus = new RoleMenuRepository(context);
            MenuGroups = new MenuGroupRepository(context);
            UserRoles = new UserRoleRepository(context);
            company = new CompanyRepository(context);
            bus = new BusinessLineRepository(context);
            cost = new CostCenterRepository(context);
            reg = new AssetRegistration(context);
            assetClass = new AssetClassification(context);
            accountChart = new ChartRepository(context);
        }

        public IUserRepository Users { get; set; }

        public IUserRoleRepository UserRoles { get; set; }

        public IMenuRepository Menus { get; set; }

        public IRoleMenuRepository RoleMenus { get; set; }

        public IMenuGroupRepository MenuGroups { get; set; }

        public ICompany company { get; set; }

        public ICostCenterRepository cost { get; set; }

        public IBusinessLine bus { get; set; }

        public IAssetRegistration reg { get; set; }

        public IAssetClass assetClass { get; set; }

        public IAccountChart accountChart { get; set; }

        public async Task<bool> Done()
        {
           return await context.Instance.SaveChangesAsync() > 0;
        }
    }
}
