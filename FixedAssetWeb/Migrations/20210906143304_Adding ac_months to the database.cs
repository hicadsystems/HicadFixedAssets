using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FixedAssetWeb.Migrations
{
    public partial class Addingac_monthstothedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "reclassdepr",
                table: "nac_company",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "nac_company",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ac_Months",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cmonth = table.Column<string>(maxLength: 2, nullable: true),
                    mthdesc = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ac_Months", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ac_Months");

            migrationBuilder.DropColumn(
                name: "reclassdepr",
                table: "nac_company");

            migrationBuilder.DropColumn(
                name: "status",
                table: "nac_company");
        }
    }
}
