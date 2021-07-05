using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV36 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_IndicadorEstrategicos_IdIndicadorEstrategico",
                schema: "planifica",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_IdIndicadorEstrategico",
                schema: "planifica",
                table: "Productos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdIndicadorEstrategico",
                schema: "planifica",
                table: "Productos",
                column: "IdIndicadorEstrategico");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_IndicadorEstrategicos_IdIndicadorEstrategico",
                schema: "planifica",
                table: "Productos",
                column: "IdIndicadorEstrategico",
                principalSchema: "planifica",
                principalTable: "IndicadorEstrategicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
