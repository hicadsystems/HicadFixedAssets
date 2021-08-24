using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FixedAssetWeb.Migrations
{
    public partial class Addingfa_gdepreciationtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fa_gdepreciations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    assetcode = table.Column<string>(maxLength: 20, nullable: false),
                    assetyear = table.Column<string>(maxLength: 4, nullable: false),
                    assetmonth = table.Column<string>(maxLength: 2, nullable: false),
                    period = table.Column<string>(maxLength: 6, nullable: true),
                    assetdesc = table.Column<string>(maxLength: 100, nullable: true),
                    purchval = table.Column<decimal>(nullable: true),
                    purchdate = table.Column<DateTime>(nullable: true),
                    newclassval = table.Column<decimal>(nullable: true),
                    oldclassval = table.Column<decimal>(nullable: true),
                    newdeptval = table.Column<decimal>(nullable: true),
                    olddeptval = table.Column<decimal>(nullable: true),
                    accum_depr = table.Column<decimal>(nullable: true),
                    calc_date = table.Column<DateTime>(nullable: true),
                    userid = table.Column<string>(maxLength: 20, nullable: true),
                    oldloc = table.Column<string>(maxLength: 50, nullable: true),
                    newloc = table.Column<string>(maxLength: 50, nullable: true),
                    oldclass = table.Column<string>(maxLength: 50, nullable: true),
                    newclass = table.Column<string>(maxLength: 50, nullable: true),
                    bookval = table.Column<decimal>(nullable: true),
                    depreciation = table.Column<float>(nullable: true),
                    cost_acctcode = table.Column<string>(maxLength: 15, nullable: true),
                    depr_acctcode = table.Column<string>(maxLength: 15, nullable: true),
                    exps_acctcode = table.Column<string>(maxLength: 15, nullable: true),
                    busdesc = table.Column<string>(maxLength: 20, nullable: true),
                    mondesc = table.Column<string>(maxLength: 20, nullable: true),
                    busline = table.Column<string>(maxLength: 20, nullable: true),
                    loc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fa_gdepreciations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fa_gdepreciations");
        }
    }
}
