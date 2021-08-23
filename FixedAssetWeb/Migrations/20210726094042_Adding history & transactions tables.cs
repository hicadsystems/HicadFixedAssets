using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FixedAssetWeb.Migrations
{
    public partial class Addinghistorytransactionstables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "fa_history");

            //migrationBuilder.DropTable(
            //    name: "fa_transaction");

            migrationBuilder.CreateTable(
                name: "fa_historys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    assetCode = table.Column<string>(maxLength: 20, nullable: true),
                    assetdesc = table.Column<string>(maxLength: 50, nullable: true),
                    newclass = table.Column<string>(maxLength: 2, nullable: true),
                    oldclass = table.Column<string>(maxLength: 2, nullable: true),
                    newloc = table.Column<string>(maxLength: 15, nullable: true),
                    oldloc = table.Column<string>(maxLength: 15, nullable: true),
                    Busline = table.Column<string>(maxLength: 2, nullable: true),
                    Purchdate = table.Column<DateTime>(nullable: false),
                    Revaldate = table.Column<DateTime>(nullable: false),
                    Reclassdate = table.Column<DateTime>(nullable: false),
                    movedate = table.Column<DateTime>(nullable: false),
                    Dispdate = table.Column<DateTime>(nullable: false),
                    Purchval = table.Column<decimal>(nullable: false),
                    Accum_depre = table.Column<decimal>(nullable: false),
                    Dispval = table.Column<decimal>(nullable: false),
                    newRevalval = table.Column<decimal>(nullable: false),
                    oldrevalval = table.Column<decimal>(nullable: false),
                    insrenewdate = table.Column<DateTime>(nullable: false),
                    Insuredval = table.Column<decimal>(nullable: false),
                    userid = table.Column<string>(maxLength: 15, nullable: true),
                    lastopendate = table.Column<DateTime>(nullable: false),
                    period = table.Column<string>(maxLength: 8, nullable: true),
                    oldrenewdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fa_historys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fa_transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    assetCode = table.Column<string>(maxLength: 20, nullable: true),
                    assetdesc = table.Column<string>(maxLength: 50, nullable: true),
                    Class = table.Column<string>(maxLength: 2, nullable: true),
                    Dept = table.Column<string>(maxLength: 15, nullable: true),
                    Busline = table.Column<string>(maxLength: 2, nullable: true),
                    Purchdate = table.Column<DateTime>(nullable: false),
                    Revaldate = table.Column<DateTime>(nullable: false),
                    Reclassdate = table.Column<DateTime>(nullable: false),
                    movedate = table.Column<DateTime>(nullable: false),
                    Dispdate = table.Column<DateTime>(nullable: false),
                    Purchval = table.Column<decimal>(nullable: false),
                    Accum_depre = table.Column<decimal>(nullable: false),
                    Dispval = table.Column<decimal>(nullable: false),
                    Revalval = table.Column<decimal>(nullable: false),
                    Insurdate = table.Column<DateTime>(nullable: false),
                    Insuredval = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fa_transactions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "fa_historys");

            //migrationBuilder.DropTable(
            //    name: "fa_transactions");

            migrationBuilder.CreateTable(
                name: "fa_history",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Accum_depre = table.Column<decimal>(nullable: false),
                    Busline = table.Column<string>(maxLength: 2, nullable: true),
                    Dispdate = table.Column<DateTime>(nullable: false),
                    Dispval = table.Column<decimal>(nullable: false),
                    Insuredval = table.Column<decimal>(nullable: false),
                    Purchdate = table.Column<DateTime>(nullable: false),
                    Purchval = table.Column<decimal>(nullable: false),
                    Reclassdate = table.Column<DateTime>(nullable: false),
                    Revaldate = table.Column<DateTime>(nullable: false),
                    assetCode = table.Column<string>(maxLength: 20, nullable: true),
                    assetdesc = table.Column<string>(maxLength: 50, nullable: true),
                    insrenewdate = table.Column<DateTime>(nullable: false),
                    lastopendate = table.Column<DateTime>(nullable: false),
                    movedate = table.Column<DateTime>(nullable: false),
                    newRevalval = table.Column<decimal>(nullable: false),
                    newclass = table.Column<string>(maxLength: 2, nullable: true),
                    newloc = table.Column<string>(maxLength: 15, nullable: true),
                    oldclass = table.Column<string>(maxLength: 2, nullable: true),
                    oldloc = table.Column<string>(maxLength: 15, nullable: true),
                    oldrenewdate = table.Column<DateTime>(nullable: false),
                    oldrevalval = table.Column<decimal>(nullable: false),
                    period = table.Column<string>(maxLength: 8, nullable: true),
                    userid = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fa_history", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fa_transaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Accum_depre = table.Column<decimal>(nullable: false),
                    Busline = table.Column<string>(maxLength: 2, nullable: true),
                    Class = table.Column<string>(maxLength: 2, nullable: true),
                    Dept = table.Column<string>(maxLength: 15, nullable: true),
                    Dispdate = table.Column<DateTime>(nullable: false),
                    Dispval = table.Column<decimal>(nullable: false),
                    Insurdate = table.Column<DateTime>(nullable: false),
                    Insuredval = table.Column<decimal>(nullable: false),
                    Purchdate = table.Column<DateTime>(nullable: false),
                    Purchval = table.Column<decimal>(nullable: false),
                    Reclassdate = table.Column<DateTime>(nullable: false),
                    Revaldate = table.Column<DateTime>(nullable: false),
                    Revalval = table.Column<decimal>(nullable: false),
                    assetCode = table.Column<string>(maxLength: 20, nullable: true),
                    assetdesc = table.Column<string>(maxLength: 50, nullable: true),
                    movedate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fa_transaction", x => x.Id);
                });
        }
    }
}
