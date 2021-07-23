﻿// <auto-generated />
using System;
using FixedAssetWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FixedAssetWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FixedAssetCore.Core.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("FixedAssetCore.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ResetPasswordCode");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<DateTime>("UpdatedOn");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("FixedAssetCore.Core.Entities.fa_Assetsreg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Accum_depre");

                    b.Property<string>("Busline")
                        .HasMaxLength(2);

                    b.Property<string>("Class")
                        .HasMaxLength(2);

                    b.Property<string>("Dept")
                        .HasMaxLength(15);

                    b.Property<string>("Dispdate")
                        .HasMaxLength(8);

                    b.Property<decimal?>("Dispval");

                    b.Property<string>("Insurdate")
                        .HasMaxLength(8);

                    b.Property<decimal?>("Insuredval");

                    b.Property<string>("Purchdate")
                        .HasMaxLength(8);

                    b.Property<decimal?>("Purchval");

                    b.Property<string>("Reclassdate")
                        .HasMaxLength(8);

                    b.Property<string>("Revaldate")
                        .HasMaxLength(8);

                    b.Property<decimal?>("Revalval");

                    b.Property<string>("assetCode")
                        .HasMaxLength(20);

                    b.Property<string>("assetDesc")
                        .HasMaxLength(100);

                    b.Property<decimal?>("depr_rate");

                    b.Property<string>("movedate")
                        .HasMaxLength(8);

                    b.Property<decimal?>("year_depr");

                    b.HasKey("Id");

                    b.ToTable("fa_Assetsreg");
                });

            modelBuilder.Entity("FixedAssetCore.Core.Entities.fa_Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<string>("Code");

                    b.Property<string>("Controller");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<int?>("MenuGroupId");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL");

                    b.HasIndex("MenuGroupId");

                    b.ToTable("fa_Menus");
                });

            modelBuilder.Entity("FixedAssetCore.Core.Entities.fa_MenuGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("fa_MenuGroups");
                });

            modelBuilder.Entity("FixedAssetCore.Core.Entities.fa_RoleMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsActive");

                    b.Property<int>("MenuId");

                    b.Property<int>("RoleId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("RoleId");

                    b.ToTable("fa_RoleMenus");
                });

            modelBuilder.Entity("FixedAssetCore.Core.Entities.fa_class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Deprmethod")
                        .HasMaxLength(1);

                    b.Property<decimal>("Deprrate");

                    b.Property<string>("Led_accum_depr_code")
                        .HasMaxLength(15);

                    b.Property<string>("Led_cost_code")
                        .HasMaxLength(15);

                    b.Property<string>("Led_exp_code")
                        .HasMaxLength(15);

                    b.Property<string>("classcode")
                        .HasMaxLength(2);

                    b.Property<string>("classdesc")
                        .HasMaxLength(60);

                    b.Property<string>("rank")
                        .HasMaxLength(1);

                    b.HasKey("Id");

                    b.ToTable("fa_class");
                });

            modelBuilder.Entity("FixedAssetCore.Core.Entities.nac_balsheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("bl_code");

                    b.Property<string>("bl_desc");

                    b.Property<string>("createdby");

                    b.Property<DateTime?>("datecreated");

                    b.HasKey("Id");

                    b.ToTable("nac_balsheets");
                });

            modelBuilder.Entity("FixedAssetCore.Core.Entities.nac_businessline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.Property<string>("createdby");

                    b.Property<DateTime?>("datecreated");

                    b.Property<string>("fundacct");

                    b.Property<string>("incomeacct");

                    b.Property<string>("interestacct");

                    b.Property<int>("jvno");

                    b.Property<int>("paymentno");

                    b.Property<int>("processingMonth");

                    b.Property<int>("processingYear");

                    b.Property<string>("profitacct");

                    b.Property<int>("receiptno");

                    b.Property<DateTime?>("startDate");

                    b.Property<string>("trusteeacct");

                    b.HasKey("Id");

                    b.ToTable("nac_businessline");
                });

            modelBuilder.Entity("FixedAssetCore.Core.Entities.nac_chart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("acctcode");

                    b.Property<string>("balSheetCode");

                    b.Property<string>("createdby");

                    b.Property<DateTime?>("datecreated");

                    b.Property<string>("description");

                    b.Property<bool>("ispersonel");

                    b.Property<string>("mainAccountCode");

                    b.Property<string>("subtype");

                    b.HasKey("Id");

                    b.ToTable("nac_charts");
                });

            modelBuilder.Entity("FixedAssetCore.Core.Entities.nac_company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Processyear");

                    b.Property<string>("box");

                    b.Property<string>("comp_code");

                    b.Property<string>("comp_name");

                    b.Property<string>("createdby");

                    b.Property<DateTime>("datecreated");

                    b.Property<string>("email");

                    b.Property<string>("email_pword");

                    b.Property<string>("hrlink");

                    b.Property<string>("lg");

                    b.Property<string>("mthly_tax");

                    b.Property<string>("processmonth");

                    b.Property<string>("retireage");

                    b.Property<string>("runtype");

                    b.Property<string>("salaryscale");

                    b.Property<string>("serveraddr");

                    b.Property<string>("serverport");

                    b.Property<string>("state");

                    b.Property<string>("tel");

                    b.Property<string>("town");

                    b.HasKey("Id");

                    b.ToTable("nac_company");
                });

            modelBuilder.Entity("FixedAssetCore.Core.Entities.nac_costcenters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("unitcode")
                        .HasMaxLength(5);

                    b.Property<string>("unitdesc")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("nac_costcenters");
                });

            modelBuilder.Entity("FixedAssetCore.Core.Entities.nac_mainact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("createdby");

                    b.Property<DateTime?>("datecreated");

                    b.Property<string>("description");

                    b.Property<string>("maincode");

                    b.Property<string>("nac_balsheet_bl_code");

                    b.Property<string>("shortname");

                    b.Property<string>("subtype");

                    b.HasKey("Id");

                    b.ToTable("nac_mainacts");
                });

            modelBuilder.Entity("FixedAssetCore.Core.Entities.nac_sub_type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("subtype");

                    b.Property<string>("subtypedesc");

                    b.HasKey("Id");

                    b.ToTable("nac_sub_Types");
                });

            modelBuilder.Entity("FixedAssetCore.Entities.fa_history", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Accum_depre");

                    b.Property<string>("Busline")
                        .HasMaxLength(2);

                    b.Property<DateTime>("Dispdate");

                    b.Property<decimal>("Dispval");

                    b.Property<decimal>("Insuredval");

                    b.Property<DateTime>("Purchdate");

                    b.Property<decimal>("Purchval");

                    b.Property<DateTime>("Reclassdate");

                    b.Property<DateTime>("Revaldate");

                    b.Property<string>("assetCode")
                        .HasMaxLength(20);

                    b.Property<string>("assetdesc")
                        .HasMaxLength(50);

                    b.Property<DateTime>("insrenewdate");

                    b.Property<DateTime>("lastopendate");

                    b.Property<DateTime>("movedate");

                    b.Property<decimal>("newRevalval");

                    b.Property<string>("newclass")
                        .HasMaxLength(2);

                    b.Property<string>("newloc")
                        .HasMaxLength(15);

                    b.Property<string>("oldclass")
                        .HasMaxLength(2);

                    b.Property<string>("oldloc")
                        .HasMaxLength(15);

                    b.Property<DateTime>("oldrenewdate");

                    b.Property<decimal>("oldrevalval");

                    b.Property<string>("period")
                        .HasMaxLength(8);

                    b.Property<string>("userid")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("fa_history");
                });

            modelBuilder.Entity("FixedAssetCore.Entities.fa_transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Accum_depre");

                    b.Property<string>("Busline")
                        .HasMaxLength(2);

                    b.Property<string>("Class")
                        .HasMaxLength(2);

                    b.Property<string>("Dept")
                        .HasMaxLength(15);

                    b.Property<DateTime>("Dispdate");

                    b.Property<decimal>("Dispval");

                    b.Property<DateTime>("Insurdate");

                    b.Property<decimal>("Insuredval");

                    b.Property<DateTime>("Purchdate");

                    b.Property<decimal>("Purchval");

                    b.Property<DateTime>("Reclassdate");

                    b.Property<DateTime>("Revaldate");

                    b.Property<decimal>("Revalval");

                    b.Property<string>("assetCode")
                        .HasMaxLength(20);

                    b.Property<string>("assetdesc")
                        .HasMaxLength(50);

                    b.Property<DateTime>("movedate");

                    b.HasKey("Id");

                    b.ToTable("fa_transaction");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<int>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FixedAssetCore.Core.Entities.UserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<int>");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasIndex("RoleId");

                    b.HasDiscriminator().HasValue("UserRole");
                });

            modelBuilder.Entity("FixedAssetCore.Core.Entities.fa_Menu", b =>
                {
                    b.HasOne("FixedAssetCore.Core.Entities.fa_MenuGroup", "MenuGroup")
                        .WithMany("fa_Menus")
                        .HasForeignKey("MenuGroupId");
                });

            modelBuilder.Entity("FixedAssetCore.Core.Entities.fa_RoleMenu", b =>
                {
                    b.HasOne("FixedAssetCore.Core.Entities.fa_Menu", "fa_Menu")
                        .WithMany("fa_RoleMenus")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FixedAssetCore.Core.Entities.Role", "Role")
                        .WithMany("fa_RoleMenus")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("FixedAssetCore.Core.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("FixedAssetCore.Core.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("FixedAssetCore.Core.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("FixedAssetCore.Core.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FixedAssetCore.Core.Entities.UserRole", b =>
                {
                    b.HasOne("FixedAssetCore.Core.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FixedAssetCore.Core.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
