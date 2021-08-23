using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FixedAssetWeb.Migrations
{
    public partial class judeinitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_fa_Assetsreg",
            //    table: "fa_Assetsreg");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "fa_Assetsreg",
            //    nullable: false,
            //    oldClrType: typeof(int))
            //    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_fa_Assetsreg",
            //    table: "fa_Assetsreg");

            //migrationBuilder.AlterColumn<string>(
            //    name: "assetCode",
            //    table: "fa_Assetsreg",
            //    maxLength: 20,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldMaxLength: 20,
            //    oldNullable: true);

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
    }
}
