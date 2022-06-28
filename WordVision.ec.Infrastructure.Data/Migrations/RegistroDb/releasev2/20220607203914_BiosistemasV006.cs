using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class BiosistemasV006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EReporteTabulados_ECantones_ECantonId",
                schema: "survey",
                table: "EReporteTabulados");

            migrationBuilder.DropForeignKey(
                name: "FK_EReporteTabulados_EEvaluaciones_EEvaluacionId",
                schema: "survey",
                table: "EReporteTabulados");

            migrationBuilder.DropForeignKey(
                name: "FK_EReporteTabulados_EIndicadores_EIndicadorId",
                schema: "survey",
                table: "EReporteTabulados");

            migrationBuilder.DropForeignKey(
                name: "FK_EReporteTabulados_EProgramas_EProgramaId",
                schema: "survey",
                table: "EReporteTabulados");

            migrationBuilder.DropForeignKey(
                name: "FK_EReporteTabulados_EProvincias_EProvinciaId",
                schema: "survey",
                table: "EReporteTabulados");

            migrationBuilder.DropForeignKey(
                name: "FK_EReporteTabulados_ERegiones_ERegionId",
                schema: "survey",
                table: "EReporteTabulados");

            migrationBuilder.AlterColumn<int>(
                name: "ERegionId",
                schema: "survey",
                table: "EReporteTabulados",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EProvinciaId",
                schema: "survey",
                table: "EReporteTabulados",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EProgramaId",
                schema: "survey",
                table: "EReporteTabulados",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EIndicadorId",
                schema: "survey",
                table: "EReporteTabulados",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EEvaluacionId",
                schema: "survey",
                table: "EReporteTabulados",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ECantonId",
                schema: "survey",
                table: "EReporteTabulados",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EReporteTabulados_ECantones_ECantonId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "ECantonId",
                principalSchema: "survey",
                principalTable: "ECantones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EReporteTabulados_EEvaluaciones_EEvaluacionId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "EEvaluacionId",
                principalSchema: "survey",
                principalTable: "EEvaluaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EReporteTabulados_EIndicadores_EIndicadorId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "EIndicadorId",
                principalSchema: "survey",
                principalTable: "EIndicadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EReporteTabulados_EProgramas_EProgramaId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "EProgramaId",
                principalSchema: "survey",
                principalTable: "EProgramas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EReporteTabulados_EProvincias_EProvinciaId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "EProvinciaId",
                principalSchema: "survey",
                principalTable: "EProvincias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EReporteTabulados_ERegiones_ERegionId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "ERegionId",
                principalSchema: "survey",
                principalTable: "ERegiones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EReporteTabulados_ECantones_ECantonId",
                schema: "survey",
                table: "EReporteTabulados");

            migrationBuilder.DropForeignKey(
                name: "FK_EReporteTabulados_EEvaluaciones_EEvaluacionId",
                schema: "survey",
                table: "EReporteTabulados");

            migrationBuilder.DropForeignKey(
                name: "FK_EReporteTabulados_EIndicadores_EIndicadorId",
                schema: "survey",
                table: "EReporteTabulados");

            migrationBuilder.DropForeignKey(
                name: "FK_EReporteTabulados_EProgramas_EProgramaId",
                schema: "survey",
                table: "EReporteTabulados");

            migrationBuilder.DropForeignKey(
                name: "FK_EReporteTabulados_EProvincias_EProvinciaId",
                schema: "survey",
                table: "EReporteTabulados");

            migrationBuilder.DropForeignKey(
                name: "FK_EReporteTabulados_ERegiones_ERegionId",
                schema: "survey",
                table: "EReporteTabulados");

            migrationBuilder.AlterColumn<int>(
                name: "ERegionId",
                schema: "survey",
                table: "EReporteTabulados",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EProvinciaId",
                schema: "survey",
                table: "EReporteTabulados",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "EProgramaId",
                schema: "survey",
                table: "EReporteTabulados",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "EIndicadorId",
                schema: "survey",
                table: "EReporteTabulados",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "EEvaluacionId",
                schema: "survey",
                table: "EReporteTabulados",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ECantonId",
                schema: "survey",
                table: "EReporteTabulados",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_EReporteTabulados_ECantones_ECantonId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "ECantonId",
                principalSchema: "survey",
                principalTable: "ECantones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EReporteTabulados_EEvaluaciones_EEvaluacionId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "EEvaluacionId",
                principalSchema: "survey",
                principalTable: "EEvaluaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EReporteTabulados_EIndicadores_EIndicadorId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "EIndicadorId",
                principalSchema: "survey",
                principalTable: "EIndicadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EReporteTabulados_EProgramas_EProgramaId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "EProgramaId",
                principalSchema: "survey",
                principalTable: "EProgramas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EReporteTabulados_EProvincias_EProvinciaId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "EProvinciaId",
                principalSchema: "survey",
                principalTable: "EProvincias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EReporteTabulados_ERegiones_ERegionId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "ERegionId",
                principalSchema: "survey",
                principalTable: "ERegiones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
