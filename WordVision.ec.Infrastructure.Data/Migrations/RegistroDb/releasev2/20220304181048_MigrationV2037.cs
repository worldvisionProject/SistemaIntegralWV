using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2037 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorVinculadoCE_IndicadorCicloEstrategico_IdIndicadorCicloEstrategico",
                table: "IndicadorVinculadoCE");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorVinculadoE_IndicadorEstrategicos_IdIndicadorEstrategico",
                table: "IndicadorVinculadoE");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorVinculadoPO_IndicadorProductoObjetivos_IdIndicadorProductoObjetivo",
                table: "IndicadorVinculadoPO");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorVinculadoPOA_IndicadorPOAs_IdIndicadorPOA",
                table: "IndicadorVinculadoPOA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndicadorVinculadoPOA",
                table: "IndicadorVinculadoPOA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndicadorVinculadoPO",
                table: "IndicadorVinculadoPO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndicadorVinculadoE",
                table: "IndicadorVinculadoE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndicadorVinculadoCE",
                table: "IndicadorVinculadoCE");

            migrationBuilder.RenameTable(
                name: "IndicadorVinculadoPOA",
                newName: "IndicadorVinculadoPOAs",
                newSchema: "planifica");

            migrationBuilder.RenameTable(
                name: "IndicadorVinculadoPO",
                newName: "IndicadorVinculadoPOs",
                newSchema: "planifica");

            migrationBuilder.RenameTable(
                name: "IndicadorVinculadoE",
                newName: "IndicadorVinculadoEs",
                newSchema: "planifica");

            migrationBuilder.RenameTable(
                name: "IndicadorVinculadoCE",
                newName: "IndicadorVinculadoCEs",
                newSchema: "planifica");

            migrationBuilder.RenameIndex(
                name: "IX_IndicadorVinculadoPOA_IdIndicadorPOA",
                schema: "planifica",
                table: "IndicadorVinculadoPOAs",
                newName: "IX_IndicadorVinculadoPOAs_IdIndicadorPOA");

            migrationBuilder.RenameIndex(
                name: "IX_IndicadorVinculadoPO_IdIndicadorProductoObjetivo",
                schema: "planifica",
                table: "IndicadorVinculadoPOs",
                newName: "IX_IndicadorVinculadoPOs_IdIndicadorProductoObjetivo");

            migrationBuilder.RenameIndex(
                name: "IX_IndicadorVinculadoE_IdIndicadorEstrategico",
                schema: "planifica",
                table: "IndicadorVinculadoEs",
                newName: "IX_IndicadorVinculadoEs_IdIndicadorEstrategico");

            migrationBuilder.RenameIndex(
                name: "IX_IndicadorVinculadoCE_IdIndicadorCicloEstrategico",
                schema: "planifica",
                table: "IndicadorVinculadoCEs",
                newName: "IX_IndicadorVinculadoCEs_IdIndicadorCicloEstrategico");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndicadorVinculadoPOAs",
                schema: "planifica",
                table: "IndicadorVinculadoPOAs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndicadorVinculadoPOs",
                schema: "planifica",
                table: "IndicadorVinculadoPOs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndicadorVinculadoEs",
                schema: "planifica",
                table: "IndicadorVinculadoEs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndicadorVinculadoCEs",
                schema: "planifica",
                table: "IndicadorVinculadoCEs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorVinculadoCEs_IndicadorCicloEstrategico_IdIndicadorCicloEstrategico",
                schema: "planifica",
                table: "IndicadorVinculadoCEs",
                column: "IdIndicadorCicloEstrategico",
                principalSchema: "planifica",
                principalTable: "IndicadorCicloEstrategico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorVinculadoEs_IndicadorEstrategicos_IdIndicadorEstrategico",
                schema: "planifica",
                table: "IndicadorVinculadoEs",
                column: "IdIndicadorEstrategico",
                principalSchema: "planifica",
                principalTable: "IndicadorEstrategicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorVinculadoPOAs_IndicadorPOAs_IdIndicadorPOA",
                schema: "planifica",
                table: "IndicadorVinculadoPOAs",
                column: "IdIndicadorPOA",
                principalSchema: "planifica",
                principalTable: "IndicadorPOAs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorVinculadoPOs_IndicadorProductoObjetivos_IdIndicadorProductoObjetivo",
                schema: "planifica",
                table: "IndicadorVinculadoPOs",
                column: "IdIndicadorProductoObjetivo",
                principalSchema: "planifica",
                principalTable: "IndicadorProductoObjetivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorVinculadoCEs_IndicadorCicloEstrategico_IdIndicadorCicloEstrategico",
                schema: "planifica",
                table: "IndicadorVinculadoCEs");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorVinculadoEs_IndicadorEstrategicos_IdIndicadorEstrategico",
                schema: "planifica",
                table: "IndicadorVinculadoEs");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorVinculadoPOAs_IndicadorPOAs_IdIndicadorPOA",
                schema: "planifica",
                table: "IndicadorVinculadoPOAs");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorVinculadoPOs_IndicadorProductoObjetivos_IdIndicadorProductoObjetivo",
                schema: "planifica",
                table: "IndicadorVinculadoPOs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndicadorVinculadoPOs",
                schema: "planifica",
                table: "IndicadorVinculadoPOs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndicadorVinculadoPOAs",
                schema: "planifica",
                table: "IndicadorVinculadoPOAs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndicadorVinculadoEs",
                schema: "planifica",
                table: "IndicadorVinculadoEs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndicadorVinculadoCEs",
                schema: "planifica",
                table: "IndicadorVinculadoCEs");

            migrationBuilder.RenameTable(
                name: "IndicadorVinculadoPOs",
                schema: "planifica",
                newName: "IndicadorVinculadoPO");

            migrationBuilder.RenameTable(
                name: "IndicadorVinculadoPOAs",
                schema: "planifica",
                newName: "IndicadorVinculadoPOA");

            migrationBuilder.RenameTable(
                name: "IndicadorVinculadoEs",
                schema: "planifica",
                newName: "IndicadorVinculadoE");

            migrationBuilder.RenameTable(
                name: "IndicadorVinculadoCEs",
                schema: "planifica",
                newName: "IndicadorVinculadoCE");

            migrationBuilder.RenameIndex(
                name: "IX_IndicadorVinculadoPOs_IdIndicadorProductoObjetivo",
                table: "IndicadorVinculadoPO",
                newName: "IX_IndicadorVinculadoPO_IdIndicadorProductoObjetivo");

            migrationBuilder.RenameIndex(
                name: "IX_IndicadorVinculadoPOAs_IdIndicadorPOA",
                table: "IndicadorVinculadoPOA",
                newName: "IX_IndicadorVinculadoPOA_IdIndicadorPOA");

            migrationBuilder.RenameIndex(
                name: "IX_IndicadorVinculadoEs_IdIndicadorEstrategico",
                table: "IndicadorVinculadoE",
                newName: "IX_IndicadorVinculadoE_IdIndicadorEstrategico");

            migrationBuilder.RenameIndex(
                name: "IX_IndicadorVinculadoCEs_IdIndicadorCicloEstrategico",
                table: "IndicadorVinculadoCE",
                newName: "IX_IndicadorVinculadoCE_IdIndicadorCicloEstrategico");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndicadorVinculadoPO",
                table: "IndicadorVinculadoPO",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndicadorVinculadoPOA",
                table: "IndicadorVinculadoPOA",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndicadorVinculadoE",
                table: "IndicadorVinculadoE",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndicadorVinculadoCE",
                table: "IndicadorVinculadoCE",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorVinculadoCE_IndicadorCicloEstrategico_IdIndicadorCicloEstrategico",
                table: "IndicadorVinculadoCE",
                column: "IdIndicadorCicloEstrategico",
                principalSchema: "planifica",
                principalTable: "IndicadorCicloEstrategico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorVinculadoE_IndicadorEstrategicos_IdIndicadorEstrategico",
                table: "IndicadorVinculadoE",
                column: "IdIndicadorEstrategico",
                principalSchema: "planifica",
                principalTable: "IndicadorEstrategicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorVinculadoPO_IndicadorProductoObjetivos_IdIndicadorProductoObjetivo",
                table: "IndicadorVinculadoPO",
                column: "IdIndicadorProductoObjetivo",
                principalSchema: "planifica",
                principalTable: "IndicadorProductoObjetivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorVinculadoPOA_IndicadorPOAs_IdIndicadorPOA",
                table: "IndicadorVinculadoPOA",
                column: "IdIndicadorPOA",
                principalSchema: "planifica",
                principalTable: "IndicadorPOAs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
