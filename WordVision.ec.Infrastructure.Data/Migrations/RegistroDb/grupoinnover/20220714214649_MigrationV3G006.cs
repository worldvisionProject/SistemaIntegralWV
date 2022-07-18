using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class MigrationV3G006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interacion_Donantes_IdDonante",
                schema: "donacion",
                table: "Interacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interacion",
                schema: "donacion",
                table: "Interacion");

            migrationBuilder.RenameTable(
                name: "Interacion",
                schema: "donacion",
                newName: "Interaciones",
                newSchema: "donacion");

            migrationBuilder.RenameIndex(
                name: "IX_Interacion_IdDonante",
                schema: "donacion",
                table: "Interaciones",
                newName: "IX_Interaciones_IdDonante");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interaciones",
                schema: "donacion",
                table: "Interaciones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interaciones_Donantes_IdDonante",
                schema: "donacion",
                table: "Interaciones",
                column: "IdDonante",
                principalSchema: "donacion",
                principalTable: "Donantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interaciones_Donantes_IdDonante",
                schema: "donacion",
                table: "Interaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interaciones",
                schema: "donacion",
                table: "Interaciones");

            migrationBuilder.RenameTable(
                name: "Interaciones",
                schema: "donacion",
                newName: "Interacion",
                newSchema: "donacion");

            migrationBuilder.RenameIndex(
                name: "IX_Interaciones_IdDonante",
                schema: "donacion",
                table: "Interacion",
                newName: "IX_Interacion_IdDonante");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interacion",
                schema: "donacion",
                table: "Interacion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interacion_Donantes_IdDonante",
                schema: "donacion",
                table: "Interacion",
                column: "IdDonante",
                principalSchema: "donacion",
                principalTable: "Donantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
