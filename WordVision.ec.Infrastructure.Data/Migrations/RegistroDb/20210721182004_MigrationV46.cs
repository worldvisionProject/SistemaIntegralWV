using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV46 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "IdCategoria",
                schema: "planifica",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "IdObjetivoEstra",
                schema: "planifica",
                table: "Productos");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_IndicadorEstrategicos_IdIndicadorEstrategico",
                schema: "planifica",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_IdIndicadorEstrategico",
                schema: "planifica",
                table: "Productos");

            migrationBuilder.AddColumn<string>(
                name: "IdCategoria",
                schema: "planifica",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdObjetivoEstra",
                schema: "planifica",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
