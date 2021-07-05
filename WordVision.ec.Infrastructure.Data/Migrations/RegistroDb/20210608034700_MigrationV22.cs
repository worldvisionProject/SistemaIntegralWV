using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEstructura",
                schema: "adm",
                table: "Estructuras",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "Colaboradores",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstructurasId",
                table: "Colaboradores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEstructura",
                table: "Colaboradores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Estructuras_IdEstructura",
                schema: "adm",
                table: "Estructuras",
                column: "IdEstructura");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_EstructurasId",
                table: "Colaboradores",
                column: "EstructurasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Estructuras_EstructurasId",
                table: "Colaboradores",
                column: "EstructurasId",
                principalSchema: "adm",
                principalTable: "Estructuras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estructuras_Estructuras_IdEstructura",
                schema: "adm",
                table: "Estructuras",
                column: "IdEstructura",
                principalSchema: "adm",
                principalTable: "Estructuras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Estructuras_EstructurasId",
                table: "Colaboradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Estructuras_Estructuras_IdEstructura",
                schema: "adm",
                table: "Estructuras");

            migrationBuilder.DropIndex(
                name: "IX_Estructuras_IdEstructura",
                schema: "adm",
                table: "Estructuras");

            migrationBuilder.DropIndex(
                name: "IX_Colaboradores_EstructurasId",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "IdEstructura",
                schema: "adm",
                table: "Estructuras");

            migrationBuilder.DropColumn(
                name: "Alias",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "EstructurasId",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "IdEstructura",
                table: "Colaboradores");
        }
    }
}
