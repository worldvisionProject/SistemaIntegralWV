using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorAFs_IndicadorEstrategicos_IndicadorEstrategicosId",
                schema: "planifica",
                table: "IndicadorAFs");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorEstrategicos_IndicadorEstrategicos_IdIndicaAF",
                schema: "planifica",
                table: "IndicadorEstrategicos");

            migrationBuilder.DropIndex(
                name: "IX_IndicadorEstrategicos_IdIndicaAF",
                schema: "planifica",
                table: "IndicadorEstrategicos");

            migrationBuilder.DropIndex(
                name: "IX_IndicadorAFs_IndicadorEstrategicosId",
                schema: "planifica",
                table: "IndicadorAFs");

            migrationBuilder.DropColumn(
                name: "IdIndicaAF",
                schema: "planifica",
                table: "IndicadorEstrategicos");

            migrationBuilder.DropColumn(
                name: "IndicadorEstrategicosId",
                schema: "planifica",
                table: "IndicadorAFs");

            migrationBuilder.RenameColumn(
                name: "IdIndicaAF",
                schema: "planifica",
                table: "IndicadorAFs",
                newName: "IdIndicadorEstrategico");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorAFs_IdIndicadorEstrategico",
                schema: "planifica",
                table: "IndicadorAFs",
                column: "IdIndicadorEstrategico");

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorAFs_IndicadorEstrategicos_IdIndicadorEstrategico",
                schema: "planifica",
                table: "IndicadorAFs",
                column: "IdIndicadorEstrategico",
                principalSchema: "planifica",
                principalTable: "IndicadorEstrategicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorAFs_IndicadorEstrategicos_IdIndicadorEstrategico",
                schema: "planifica",
                table: "IndicadorAFs");

            migrationBuilder.DropIndex(
                name: "IX_IndicadorAFs_IdIndicadorEstrategico",
                schema: "planifica",
                table: "IndicadorAFs");

            migrationBuilder.RenameColumn(
                name: "IdIndicadorEstrategico",
                schema: "planifica",
                table: "IndicadorAFs",
                newName: "IdIndicaAF");

            migrationBuilder.AddColumn<int>(
                name: "IdIndicaAF",
                schema: "planifica",
                table: "IndicadorEstrategicos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IndicadorEstrategicosId",
                schema: "planifica",
                table: "IndicadorAFs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorEstrategicos_IdIndicaAF",
                schema: "planifica",
                table: "IndicadorEstrategicos",
                column: "IdIndicaAF");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorAFs_IndicadorEstrategicosId",
                schema: "planifica",
                table: "IndicadorAFs",
                column: "IndicadorEstrategicosId");

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorAFs_IndicadorEstrategicos_IndicadorEstrategicosId",
                schema: "planifica",
                table: "IndicadorAFs",
                column: "IndicadorEstrategicosId",
                principalSchema: "planifica",
                principalTable: "IndicadorEstrategicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorEstrategicos_IndicadorEstrategicos_IdIndicaAF",
                schema: "planifica",
                table: "IndicadorEstrategicos",
                column: "IdIndicaAF",
                principalSchema: "planifica",
                principalTable: "IndicadorEstrategicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
