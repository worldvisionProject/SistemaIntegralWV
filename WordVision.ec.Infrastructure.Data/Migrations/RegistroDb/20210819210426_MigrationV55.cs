using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_IndicadorPOAs_IdIndicadorPOA",
                schema: "planifica",
                table: "Actividades");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorEstrategicos_FactorCriticoExitos_IdFactorCritico",
                schema: "planifica",
                table: "IndicadorEstrategicos");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorPOAs_Productos_IdProducto",
                schema: "planifica",
                table: "IndicadorPOAs");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_IndicadorEstrategicos_IdIndicadorEstrategico",
                schema: "planifica",
                table: "Productos");

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_IndicadorPOAs_IdIndicadorPOA",
                schema: "planifica",
                table: "Actividades",
                column: "IdIndicadorPOA",
                principalSchema: "planifica",
                principalTable: "IndicadorPOAs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorEstrategicos_FactorCriticoExitos_IdFactorCritico",
                schema: "planifica",
                table: "IndicadorEstrategicos",
                column: "IdFactorCritico",
                principalSchema: "planifica",
                principalTable: "FactorCriticoExitos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorPOAs_Productos_IdProducto",
                schema: "planifica",
                table: "IndicadorPOAs",
                column: "IdProducto",
                principalSchema: "planifica",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_IndicadorEstrategicos_IdIndicadorEstrategico",
                schema: "planifica",
                table: "Productos",
                column: "IdIndicadorEstrategico",
                principalSchema: "planifica",
                principalTable: "IndicadorEstrategicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_IndicadorPOAs_IdIndicadorPOA",
                schema: "planifica",
                table: "Actividades");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorEstrategicos_FactorCriticoExitos_IdFactorCritico",
                schema: "planifica",
                table: "IndicadorEstrategicos");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorPOAs_Productos_IdProducto",
                schema: "planifica",
                table: "IndicadorPOAs");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_IndicadorEstrategicos_IdIndicadorEstrategico",
                schema: "planifica",
                table: "Productos");

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_IndicadorPOAs_IdIndicadorPOA",
                schema: "planifica",
                table: "Actividades",
                column: "IdIndicadorPOA",
                principalSchema: "planifica",
                principalTable: "IndicadorPOAs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorEstrategicos_FactorCriticoExitos_IdFactorCritico",
                schema: "planifica",
                table: "IndicadorEstrategicos",
                column: "IdFactorCritico",
                principalSchema: "planifica",
                principalTable: "FactorCriticoExitos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
