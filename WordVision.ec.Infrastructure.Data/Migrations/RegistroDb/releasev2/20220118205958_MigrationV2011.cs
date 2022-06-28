using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responsabilidad_Objetivos_IdResponsabilidad",
                table: "Responsabilidad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Responsabilidad",
                table: "Responsabilidad");

            migrationBuilder.RenameTable(
                name: "Responsabilidad",
                newName: "Responsabilidades",
                newSchema: "valoracion");

            migrationBuilder.RenameIndex(
                name: "IX_Responsabilidad_IdResponsabilidad",
                schema: "valoracion",
                table: "Responsabilidades",
                newName: "IX_Responsabilidades_IdResponsabilidad");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responsabilidades",
                schema: "valoracion",
                table: "Responsabilidades",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Responsabilidades_Objetivos_IdResponsabilidad",
                schema: "valoracion",
                table: "Responsabilidades",
                column: "IdResponsabilidad",
                principalSchema: "valoracion",
                principalTable: "Objetivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responsabilidades_Objetivos_IdResponsabilidad",
                schema: "valoracion",
                table: "Responsabilidades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Responsabilidades",
                schema: "valoracion",
                table: "Responsabilidades");

            migrationBuilder.RenameTable(
                name: "Responsabilidades",
                schema: "valoracion",
                newName: "Responsabilidad");

            migrationBuilder.RenameIndex(
                name: "IX_Responsabilidades_IdResponsabilidad",
                table: "Responsabilidad",
                newName: "IX_Responsabilidad_IdResponsabilidad");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responsabilidad",
                table: "Responsabilidad",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Responsabilidad_Objetivos_IdResponsabilidad",
                table: "Responsabilidad",
                column: "IdResponsabilidad",
                principalSchema: "valoracion",
                principalTable: "Objetivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
