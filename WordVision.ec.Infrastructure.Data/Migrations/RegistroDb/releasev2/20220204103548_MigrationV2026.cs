using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2026 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnioFiscal",
                schema: "planifica",
                table: "IndicadorProductoObjetivos");

            migrationBuilder.AddColumn<int>(
                name: "AnioFiscal",
                schema: "planifica",
                table: "ProductoObjetivos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "FactorCritico",
                schema: "planifica",
                table: "EstrategiaNacionales",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnioFiscal",
                schema: "planifica",
                table: "ProductoObjetivos");

            migrationBuilder.AddColumn<int>(
                name: "AnioFiscal",
                schema: "planifica",
                table: "IndicadorProductoObjetivos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "FactorCritico",
                schema: "planifica",
                table: "EstrategiaNacionales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
