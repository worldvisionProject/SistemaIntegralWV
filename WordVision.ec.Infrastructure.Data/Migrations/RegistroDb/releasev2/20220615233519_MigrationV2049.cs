using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2049 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndicadoresPR_DetalleCatalogos_IdRubro",
                schema: "adm",
                table: "IndicadoresPR");

            migrationBuilder.DropIndex(
                name: "IX_IndicadoresPR_IdRubro",
                schema: "adm",
                table: "IndicadoresPR");

            migrationBuilder.DropColumn(
                name: "IdRubro",
                schema: "adm",
                table: "IndicadoresPR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdRubro",
                schema: "adm",
                table: "IndicadoresPR",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IndicadoresPR_IdRubro",
                schema: "adm",
                table: "IndicadoresPR",
                column: "IdRubro");

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadoresPR_DetalleCatalogos_IdRubro",
                schema: "adm",
                table: "IndicadoresPR",
                column: "IdRubro",
                principalSchema: "adm",
                principalTable: "DetalleCatalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
