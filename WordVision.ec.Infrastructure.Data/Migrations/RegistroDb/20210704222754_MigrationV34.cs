using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorEstrategicos_Productos_IdProducto",
                schema: "planifica",
                table: "IndicadorEstrategicos");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorPOAs_Productos_ProductosId",
                schema: "planifica",
                table: "IndicadorPOAs");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_ObjetivoEstrategicos_ObjetivoEstrategicosId",
                schema: "planifica",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_ObjetivoEstrategicosId",
                schema: "planifica",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_IndicadorPOAs_ProductosId",
                schema: "planifica",
                table: "IndicadorPOAs");

            migrationBuilder.DropIndex(
                name: "IX_IndicadorEstrategicos_IdProducto",
                schema: "planifica",
                table: "IndicadorEstrategicos");

            migrationBuilder.DropColumn(
                name: "ObjetivoEstrategicosId",
                schema: "planifica",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ProductosId",
                schema: "planifica",
                table: "IndicadorPOAs");

            migrationBuilder.DropColumn(
                name: "IdProducto",
                schema: "planifica",
                table: "IndicadorEstrategicos");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdIndicadorEstrategico",
                schema: "planifica",
                table: "Productos",
                column: "IdIndicadorEstrategico");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorPOAs_IdProducto",
                schema: "planifica",
                table: "IndicadorPOAs",
                column: "IdProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorPOAs_Productos_IdProducto",
                schema: "planifica",
                table: "IndicadorPOAs",
                column: "IdProducto",
                principalSchema: "planifica",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_IndicadorPOAs_Productos_IdProducto",
                schema: "planifica",
                table: "IndicadorPOAs");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_IndicadorEstrategicos_IdIndicadorEstrategico",
                schema: "planifica",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_IdIndicadorEstrategico",
                schema: "planifica",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_IndicadorPOAs_IdProducto",
                schema: "planifica",
                table: "IndicadorPOAs");

            migrationBuilder.AddColumn<int>(
                name: "ObjetivoEstrategicosId",
                schema: "planifica",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductosId",
                schema: "planifica",
                table: "IndicadorPOAs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdProducto",
                schema: "planifica",
                table: "IndicadorEstrategicos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ObjetivoEstrategicosId",
                schema: "planifica",
                table: "Productos",
                column: "ObjetivoEstrategicosId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorPOAs_ProductosId",
                schema: "planifica",
                table: "IndicadorPOAs",
                column: "ProductosId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorEstrategicos_IdProducto",
                schema: "planifica",
                table: "IndicadorEstrategicos",
                column: "IdProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorEstrategicos_Productos_IdProducto",
                schema: "planifica",
                table: "IndicadorEstrategicos",
                column: "IdProducto",
                principalSchema: "planifica",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorPOAs_Productos_ProductosId",
                schema: "planifica",
                table: "IndicadorPOAs",
                column: "ProductosId",
                principalSchema: "planifica",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_ObjetivoEstrategicos_ObjetivoEstrategicosId",
                schema: "planifica",
                table: "Productos",
                column: "ObjetivoEstrategicosId",
                principalSchema: "planifica",
                principalTable: "ObjetivoEstrategicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
