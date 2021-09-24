using FixedAssetCore.Core.Entities;
using FixedAssetCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FixedAssetCore.Core.Data
{
    public interface IAssetDbContext:IDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<fa_Menu> fa_Menus { get; set; }
        DbSet<fa_RoleMenu> fa_RoleMenus { get; set; }
        DbSet<fa_MenuGroup> fa_MenuGroups { get; set; }
        DbSet<fa_Assetsreg> fa_Assetsreg { get; set; }
        DbSet<fa_class> fa_class { get; set; }
        DbSet<nac_company> nac_company { get; set; }
        DbSet<nac_balsheet> nac_balsheets { get; set; }
        DbSet<nac_chart> nac_charts { get; set; }
        DbSet<nac_mainact> nac_mainacts { get; set; }
        DbSet<nac_sub_type> nac_sub_Types { get; set; }
        DbSet<nac_businessline> nac_businessline { get; set; }
        DbSet<nac_costcenters> nac_costcenters { get; set; }
        DbSet<fa_history> fa_historys { get; set; }
        DbSet<fa_transaction> fa_transactions { get; set; }
        DbSet<fa_gdepreciation> fa_gdepreciations { get; set; }
        DbSet<ac_month> ac_Months { get; set; }
        DbSet<fa_assetDisposal> fa_AssetDisposals { get; set; }
    }
}
