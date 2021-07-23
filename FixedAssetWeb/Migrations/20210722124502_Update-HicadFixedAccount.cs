using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FixedAssetWeb.Migrations
{
    public partial class UpdateHicadFixedAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ResetPasswordCode = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fa_Assetsreg",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    assetCode = table.Column<string>(maxLength: 20, nullable: true),
                    assetDesc = table.Column<string>(maxLength: 100, nullable: true),
                    Class = table.Column<string>(maxLength: 2, nullable: true),
                    Dept = table.Column<string>(maxLength: 15, nullable: true),
                    Busline = table.Column<string>(maxLength: 2, nullable: true),
                    Purchdate = table.Column<string>(maxLength: 8, nullable: true),
                    Revaldate = table.Column<string>(maxLength: 8, nullable: true),
                    Reclassdate = table.Column<string>(maxLength: 8, nullable: true),
                    movedate = table.Column<string>(maxLength: 8, nullable: true),
                    Dispdate = table.Column<string>(maxLength: 8, nullable: true),
                    Purchval = table.Column<decimal>(nullable: true),
                    Accum_depre = table.Column<decimal>(nullable: true),
                    Dispval = table.Column<decimal>(nullable: true),
                    Revalval = table.Column<decimal>(nullable: true),
                    Insurdate = table.Column<string>(maxLength: 8, nullable: true),
                    Insuredval = table.Column<decimal>(nullable: true),
                    year_depr = table.Column<decimal>(nullable: true),
                    depr_rate = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fa_Assetsreg", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fa_class",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    classcode = table.Column<string>(maxLength: 2, nullable: true),
                    classdesc = table.Column<string>(maxLength: 60, nullable: true),
                    Deprrate = table.Column<decimal>(nullable: false),
                    Deprmethod = table.Column<string>(maxLength: 1, nullable: true),
                    Led_cost_code = table.Column<string>(maxLength: 15, nullable: true),
                    Led_accum_depr_code = table.Column<string>(maxLength: 15, nullable: true),
                    Led_exp_code = table.Column<string>(maxLength: 15, nullable: true),
                    rank = table.Column<string>(maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fa_class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fa_MenuGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fa_MenuGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nac_balsheets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bl_code = table.Column<string>(nullable: true),
                    bl_desc = table.Column<string>(nullable: true),
                    datecreated = table.Column<DateTime>(nullable: true),
                    createdby = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nac_balsheets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nac_businessline",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    startDate = table.Column<DateTime>(nullable: true),
                    processingYear = table.Column<int>(nullable: false),
                    processingMonth = table.Column<int>(nullable: false),
                    interestacct = table.Column<string>(nullable: true),
                    incomeacct = table.Column<string>(nullable: true),
                    fundacct = table.Column<string>(nullable: true),
                    receiptno = table.Column<int>(nullable: false),
                    paymentno = table.Column<int>(nullable: false),
                    jvno = table.Column<int>(nullable: false),
                    trusteeacct = table.Column<string>(nullable: true),
                    profitacct = table.Column<string>(nullable: true),
                    createdby = table.Column<string>(nullable: true),
                    datecreated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nac_businessline", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nac_charts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    acctcode = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    mainAccountCode = table.Column<string>(nullable: true),
                    subtype = table.Column<string>(nullable: true),
                    ispersonel = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    balSheetCode = table.Column<string>(nullable: true),
                    datecreated = table.Column<DateTime>(nullable: true),
                    createdby = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nac_charts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nac_company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    comp_code = table.Column<string>(nullable: true),
                    comp_name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Processyear = table.Column<string>(nullable: true),
                    processmonth = table.Column<string>(nullable: true),
                    datecreated = table.Column<DateTime>(nullable: false),
                    createdby = table.Column<string>(nullable: true),
                    salaryscale = table.Column<string>(nullable: true),
                    retireage = table.Column<string>(nullable: true),
                    hrlink = table.Column<string>(nullable: true),
                    town = table.Column<string>(nullable: true),
                    lg = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    box = table.Column<string>(nullable: true),
                    tel = table.Column<string>(nullable: true),
                    serveraddr = table.Column<string>(nullable: true),
                    serverport = table.Column<string>(nullable: true),
                    email_pword = table.Column<string>(nullable: true),
                    mthly_tax = table.Column<string>(nullable: true),
                    runtype = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nac_company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nac_costcenters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    unitcode = table.Column<string>(maxLength: 5, nullable: true),
                    unitdesc = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nac_costcenters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nac_mainacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    maincode = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    nac_balsheet_bl_code = table.Column<string>(nullable: true),
                    subtype = table.Column<string>(nullable: true),
                    shortname = table.Column<string>(nullable: true),
                    datecreated = table.Column<DateTime>(nullable: true),
                    createdby = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nac_mainacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nac_sub_Types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    subtype = table.Column<string>(nullable: true),
                    subtypedesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nac_sub_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fa_Menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MenuGroupId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fa_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fa_Menus_fa_MenuGroups_MenuGroupId",
                        column: x => x.MenuGroupId,
                        principalTable: "fa_MenuGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "fa_RoleMenus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fa_RoleMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fa_RoleMenus_fa_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "fa_Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fa_RoleMenus_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_fa_Menus_Code",
                table: "fa_Menus",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_fa_Menus_MenuGroupId",
                table: "fa_Menus",
                column: "MenuGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_fa_RoleMenus_MenuId",
                table: "fa_RoleMenus",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_fa_RoleMenus_RoleId",
                table: "fa_RoleMenus",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "fa_Assetsreg");

            migrationBuilder.DropTable(
                name: "fa_class");

            migrationBuilder.DropTable(
                name: "fa_RoleMenus");

            migrationBuilder.DropTable(
                name: "nac_balsheets");

            migrationBuilder.DropTable(
                name: "nac_businessline");

            migrationBuilder.DropTable(
                name: "nac_charts");

            migrationBuilder.DropTable(
                name: "nac_company");

            migrationBuilder.DropTable(
                name: "nac_costcenters");

            migrationBuilder.DropTable(
                name: "nac_mainacts");

            migrationBuilder.DropTable(
                name: "nac_sub_Types");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "fa_Menus");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "fa_MenuGroups");
        }
    }
}
