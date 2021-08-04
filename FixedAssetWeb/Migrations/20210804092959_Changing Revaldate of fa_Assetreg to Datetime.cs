using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FixedAssetWeb.Migrations
{
    public partial class ChangingRevaldateoffa_AssetregtoDatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_fa_Assetsreg",
            //    table: "fa_Assetsreg");

            migrationBuilder.AlterColumn<DateTime>(
                name: "movedate",
                table: "fa_Assetsreg",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 8,
                oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "assetCode",
            //    table: "fa_Assetsreg",
            //    maxLength: 20,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldMaxLength: 20,
            //    oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Revaldate",
                table: "fa_Assetsreg",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Reclassdate",
                table: "fa_Assetsreg",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Purchdate",
                table: "fa_Assetsreg",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Insurdate",
                table: "fa_Assetsreg",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dispdate",
                table: "fa_Assetsreg",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 8,
                oldNullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "fa_Assetsreg",
            //    nullable: false,
            //    oldClrType: typeof(int))
            //    .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_fa_Assetsreg",
            //    table: "fa_Assetsreg",
            //    column: "assetCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_fa_Assetsreg",
            //    table: "fa_Assetsreg");

            migrationBuilder.AlterColumn<string>(
                name: "movedate",
                table: "fa_Assetsreg",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Revaldate",
                table: "fa_Assetsreg",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Reclassdate",
                table: "fa_Assetsreg",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Purchdate",
                table: "fa_Assetsreg",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Insurdate",
                table: "fa_Assetsreg",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "fa_Assetsreg",
            //    nullable: false,
            //    oldClrType: typeof(int))
            //    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Dispdate",
                table: "fa_Assetsreg",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "assetCode",
            //    table: "fa_Assetsreg",
            //    maxLength: 20,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldMaxLength: 20);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_fa_Assetsreg",
            //    table: "fa_Assetsreg",
            //    column: "Id");
        }
    }
}
