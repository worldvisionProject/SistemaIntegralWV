using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_IdEstructura",
                table: "Colaboradores",
                column: "IdEstructura");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Estructuras_IdEstructura",
                table: "Colaboradores",
                column: "IdEstructura",
                principalSchema: "adm",
                principalTable: "Estructuras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Estructuras_IdEstructura",
                table: "Colaboradores");

            migrationBuilder.DropIndex(
                name: "IX_Colaboradores_IdEstructura",
                table: "Colaboradores");
        }
    }
}
