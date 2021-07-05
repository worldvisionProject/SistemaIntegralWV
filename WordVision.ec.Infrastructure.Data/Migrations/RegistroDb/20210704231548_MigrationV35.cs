using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdGestion",
                schema: "planifica",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdGestion",
                schema: "planifica",
                table: "Productos",
                column: "IdGestion");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Gestiones_IdGestion",
                schema: "planifica",
                table: "Productos",
                column: "IdGestion",
                principalSchema: "planifica",
                principalTable: "Gestiones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Gestiones_IdGestion",
                schema: "planifica",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_IdGestion",
                schema: "planifica",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "IdGestion",
                schema: "planifica",
                table: "Productos");
        }
    }
}
