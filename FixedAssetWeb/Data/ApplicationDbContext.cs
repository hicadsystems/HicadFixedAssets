using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.Data
{
    public class ApplicationDbContext: IdentityDbContext<User,Role, int>,IAssetDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
       {
       }

    public DbContext Instance => this;

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<fa_MenuGroup> fa_MenuGroups { get; set; }
    public DbSet<fa_Menu> fa_Menus { get; set; }
    public DbSet<fa_RoleMenu> fa_RoleMenus { get; set; }
    public DbSet<fa_Assetsreg> fa_Assetsreg { get; set; }
    public DbSet<fa_class> fa_class { get; set; }
    public DbSet<nac_company> nac_company { get; set; }
    public DbSet<nac_businessline> nac_businessline { get; set; }
    public DbSet<nac_costcenters> nac_costcenters { get; set; }
    public DbSet<nac_chart> nac_charts { get; set; }
    public DbSet<nac_balsheet> nac_balsheets { get ; set ; }
    public DbSet<nac_mainact> nac_mainacts { get ; set ; }
    public DbSet<nac_sub_type> nac_sub_Types { get ; set ; }

    public DbSet<fa_history> fa_historys { get; set; }
    public DbSet<fa_transaction> fa_transactions { get; set; }
    public DbSet<fa_gdepreciation> fa_gdepreciations { get; set; }

    public DbSet<ac_month> ac_Months { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<fa_Menu>()
            .HasIndex(x => x.Code)
            .IsUnique();

        builder.Entity<fa_RoleMenu>()
            .Property(e => e.Id)
            .UseSqlServerIdentityColumn();



        builder.Entity<fa_Menu>()
            .Property(e => e.Id)
            .UseSqlServerIdentityColumn();

      

        builder.Entity<UserRole>()
            .HasOne(x => x.Role)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(x => x.RoleId);

        builder.Entity<UserRole>()
            .HasOne(x => x.User)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(x => x.UserId);

        builder.Entity<fa_RoleMenu>()
            .HasKey(x => x.Id);

        builder.Entity<fa_RoleMenu>()
            .HasOne(x => x.Role)
            .WithMany(x => x.fa_RoleMenus)
            .HasForeignKey(x => x.RoleId);

        builder.Entity<fa_RoleMenu>()
            .HasOne(x => x.fa_Menu)
            .WithMany(x => x.fa_RoleMenus)
            .HasForeignKey(x => x.MenuId);

            //builder.Entity<fa_Assetsreg>()
            //        .HasKey(x => x.assetCode);
    }
   }
}

