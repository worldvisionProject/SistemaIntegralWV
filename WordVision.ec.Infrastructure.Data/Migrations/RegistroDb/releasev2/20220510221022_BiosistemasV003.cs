using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class BiosistemasV003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "enk_Fecha",
                schema: "survey",
                table: "EncuestaKobos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "EEvaluaciones",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eva_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eva_Desde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    eva_Hasta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EEvaluaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EIndicadores",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ind_LogFrame = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ind_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ind_Resultado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ind_Definicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ind_Fuente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ind_Seccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ind_Preguntas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ind_Medicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    int_PlanTabulados = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ind_UnidadMedida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ind_Frecuencia = table.Column<int>(type: "int", nullable: false),
                    EProgramaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EIndicadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EIndicadores_EProgramas_EProgramaId",
                        column: x => x.EProgramaId,
                        principalSchema: "survey",
                        principalTable: "EProgramas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EIndicadores_EProgramaId",
                schema: "survey",
                table: "EIndicadores",
                column: "EProgramaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EEvaluaciones",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "EIndicadores",
                schema: "survey");

            migrationBuilder.AlterColumn<DateTime>(
                name: "enk_Fecha",
                schema: "survey",
                table: "EncuestaKobos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
