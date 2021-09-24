using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FixedAssetWeb.Migrations
{
    public partial class Addingfa_assetDisposaltable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fa_AssetDisposals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    assetCode = table.Column<string>(maxLength: 20, nullable: true),
                    assetDesc = table.Column<string>(maxLength: 100, nullable: true),
                    Class = table.Column<string>(maxLength: 2, nullable: true),
                    Dept = table.Column<string>(maxLength: 15, nullable: true),
                    Busline = table.Column<string>(maxLength: 2, nullable: true),
                    Purchdate = table.Column<DateTime>(nullable: true),
                    Revaldate = table.Column<DateTime>(nullable: true),
                    Reclassdate = table.Column<DateTime>(nullable: true),
                    movedate = table.Column<DateTime>(nullable: true),
                    Dispdate = table.Column<DateTime>(nullable: true),
                    Purchval = table.Column<decimal>(nullable: true),
                    Accum_depre = table.Column<decimal>(nullable: true),
                    Dispval = table.Column<decimal>(nullable: true),
                    Revalval = table.Column<decimal>(nullable: true),
                    Insurdate = table.Column<DateTime>(nullable: true),
                    Insuredval = table.Column<decimal>(nullable: true),
                    year_depr = table.Column<decimal>(nullable: true),
                    depr_rate = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fa_AssetDisposals", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fa_AssetDisposals");
        }
    }
}
