using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2048 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cobertura",
                schema: "adm",
                table: "LogFrames",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdIndicadorPR",
                schema: "adm",
                table: "LogFrames",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdProyectoTecnico",
                schema: "adm",
                table: "LogFrames",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdRubro",
                schema: "adm",
                table: "LogFrames",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdSectorProgramatico",
                schema: "adm",
                table: "LogFrames",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTipoActividad",
                schema: "adm",
                table: "LogFrames",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogFrames_IdIndicadorPR",
                schema: "adm",
                table: "LogFrames",
                column: "IdIndicadorPR");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrames_IdProyectoTecnico",
                schema: "adm",
                table: "LogFrames",
                column: "IdProyectoTecnico");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrames_IdRubro",
                schema: "adm",
                table: "LogFrames",
                column: "IdRubro");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrames_IdSectorProgramatico",
                schema: "adm",
                table: "LogFrames",
                column: "IdSectorProgramatico");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrames_IdTipoActividad",
                schema: "adm",
                table: "LogFrames",
                column: "IdTipoActividad");

            migrationBuilder.AddForeignKey(
                name: "FK_LogFrames_DetalleCatalogos_IdRubro",
                schema: "adm",
                table: "LogFrames",
                column: "IdRubro",
                principalSchema: "adm",
                principalTable: "DetalleCatalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LogFrames_DetalleCatalogos_IdSectorProgramatico",
                schema: "adm",
                table: "LogFrames",
                column: "IdSectorProgramatico",
                principalSchema: "adm",
                principalTable: "DetalleCatalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LogFrames_DetalleCatalogos_IdTipoActividad",
                schema: "adm",
                table: "LogFrames",
                column: "IdTipoActividad",
                principalSchema: "adm",
                principalTable: "DetalleCatalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LogFrames_IndicadoresPR_IdIndicadorPR",
                schema: "adm",
                table: "LogFrames",
                column: "IdIndicadorPR",
                principalSchema: "adm",
                principalTable: "IndicadoresPR",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LogFrames_ProyectoTecnicos_IdProyectoTecnico",
                schema: "adm",
                table: "LogFrames",
                column: "IdProyectoTecnico",
                principalSchema: "adm",
                principalTable: "ProyectoTecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogFrames_DetalleCatalogos_IdRubro",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropForeignKey(
                name: "FK_LogFrames_DetalleCatalogos_IdSectorProgramatico",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropForeignKey(
                name: "FK_LogFrames_DetalleCatalogos_IdTipoActividad",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropForeignKey(
                name: "FK_LogFrames_IndicadoresPR_IdIndicadorPR",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropForeignKey(
                name: "FK_LogFrames_ProyectoTecnicos_IdProyectoTecnico",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropIndex(
                name: "IX_LogFrames_IdIndicadorPR",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropIndex(
                name: "IX_LogFrames_IdProyectoTecnico",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropIndex(
                name: "IX_LogFrames_IdRubro",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropIndex(
                name: "IX_LogFrames_IdSectorProgramatico",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropIndex(
                name: "IX_LogFrames_IdTipoActividad",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropColumn(
                name: "Cobertura",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropColumn(
                name: "IdIndicadorPR",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropColumn(
                name: "IdProyectoTecnico",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropColumn(
                name: "IdRubro",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropColumn(
                name: "IdSectorProgramatico",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropColumn(
                name: "IdTipoActividad",
                schema: "adm",
                table: "LogFrames");
        }
    }
}
