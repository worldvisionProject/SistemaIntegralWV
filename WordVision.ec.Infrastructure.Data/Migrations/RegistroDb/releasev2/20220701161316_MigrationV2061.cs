using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2061 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleProyectoITTs_LogFrames_IdLogFrame",
                schema: "planifica",
                table: "DetalleProyectoITTs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoITTs_ProgramaAreas_IdProgramaArea",
                schema: "planifica",
                table: "ProyectoITTs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoITTs_ProyectoTecnicos_IdProyectoTecnico",
                schema: "planifica",
                table: "ProyectoITTs");

            migrationBuilder.DropIndex(
                name: "IX_DetalleProyectoITTs_IdLogFrame",
                schema: "planifica",
                table: "DetalleProyectoITTs");

            migrationBuilder.DropColumn(
                name: "IdLogFrame",
                schema: "planifica",
                table: "DetalleProyectoITTs");

            migrationBuilder.RenameColumn(
                name: "IdProyectoTecnico",
                schema: "planifica",
                table: "ProyectoITTs",
                newName: "IdLogFrameOutCome");

            migrationBuilder.RenameColumn(
                name: "IdProgramaArea",
                schema: "planifica",
                table: "ProyectoITTs",
                newName: "IdFaseProgramaArea");

            migrationBuilder.RenameIndex(
                name: "IX_ProyectoITTs_IdProyectoTecnico",
                schema: "planifica",
                table: "ProyectoITTs",
                newName: "IX_ProyectoITTs_IdLogFrameOutCome");

            migrationBuilder.RenameIndex(
                name: "IX_ProyectoITTs_IdProgramaArea",
                schema: "planifica",
                table: "ProyectoITTs",
                newName: "IX_ProyectoITTs_IdFaseProgramaArea");

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectoITTs_FaseProgramaAreas_IdFaseProgramaArea",
                schema: "planifica",
                table: "ProyectoITTs",
                column: "IdFaseProgramaArea",
                principalSchema: "indicador",
                principalTable: "FaseProgramaAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectoITTs_LogFrames_IdLogFrameOutCome",
                schema: "planifica",
                table: "ProyectoITTs",
                column: "IdLogFrameOutCome",
                principalSchema: "adm",
                principalTable: "LogFrames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoITTs_FaseProgramaAreas_IdFaseProgramaArea",
                schema: "planifica",
                table: "ProyectoITTs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoITTs_LogFrames_IdLogFrameOutCome",
                schema: "planifica",
                table: "ProyectoITTs");

            migrationBuilder.RenameColumn(
                name: "IdLogFrameOutCome",
                schema: "planifica",
                table: "ProyectoITTs",
                newName: "IdProyectoTecnico");

            migrationBuilder.RenameColumn(
                name: "IdFaseProgramaArea",
                schema: "planifica",
                table: "ProyectoITTs",
                newName: "IdProgramaArea");

            migrationBuilder.RenameIndex(
                name: "IX_ProyectoITTs_IdLogFrameOutCome",
                schema: "planifica",
                table: "ProyectoITTs",
                newName: "IX_ProyectoITTs_IdProyectoTecnico");

            migrationBuilder.RenameIndex(
                name: "IX_ProyectoITTs_IdFaseProgramaArea",
                schema: "planifica",
                table: "ProyectoITTs",
                newName: "IX_ProyectoITTs_IdProgramaArea");

            migrationBuilder.AddColumn<int>(
                name: "IdLogFrame",
                schema: "planifica",
                table: "DetalleProyectoITTs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProyectoITTs_IdLogFrame",
                schema: "planifica",
                table: "DetalleProyectoITTs",
                column: "IdLogFrame");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleProyectoITTs_LogFrames_IdLogFrame",
                schema: "planifica",
                table: "DetalleProyectoITTs",
                column: "IdLogFrame",
                principalSchema: "adm",
                principalTable: "LogFrames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectoITTs_ProgramaAreas_IdProgramaArea",
                schema: "planifica",
                table: "ProyectoITTs",
                column: "IdProgramaArea",
                principalSchema: "adm",
                principalTable: "ProgramaAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectoITTs_ProyectoTecnicos_IdProyectoTecnico",
                schema: "planifica",
                table: "ProyectoITTs",
                column: "IdProyectoTecnico",
                principalSchema: "adm",
                principalTable: "ProyectoTecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
