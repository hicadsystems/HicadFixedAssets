using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FixedAssetWeb.Migrations
{
    public partial class AddingminBookBalancecolumntocompanytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "datecreated",
                table: "nac_company",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<decimal>(
                name: "MinBookVal",
                table: "nac_company",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinBookVal",
                table: "nac_company");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datecreated",
                table: "nac_company",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
