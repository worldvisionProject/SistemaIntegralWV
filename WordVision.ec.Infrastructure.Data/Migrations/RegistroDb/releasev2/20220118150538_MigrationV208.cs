using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV208 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responsabilidad_Objetivos_IdResponsabilidad",
                table: "Responsabilidad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Responsabilidad",
                table: "Responsabilidad");

            migrationBuilder.RenameTable(
                name: "Responsabilidad",
                newName: "Responsabilidades",
                newSchema: "valoracion");

            migrationBuilder.RenameIndex(
                name: "IX_Responsabilidad_IdResponsabilidad",
                schema: "valoracion",
                table: "Responsabilidades",
                newName: "IX_Responsabilidades_IdResponsabilidad");

            migrationBuilder.AddColumn<int>(
                name: "TipoObjetivo",
                schema: "valoracion",
                table: "Resultados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DatoManual1",
                schema: "valoracion",
                table: "PlanificacionResultados",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatoManual2",
                schema: "valoracion",
                table: "PlanificacionResultados",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DatoManual3",
                schema: "valoracion",
                table: "PlanificacionResultados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEstructura",
                schema: "valoracion",
                table: "Responsabilidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responsabilidades",
                schema: "valoracion",
                table: "Responsabilidades",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Competencias",
                schema: "valoracion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNivel = table.Column<int>(type: "int", nullable: false),
                    IdCompetencia = table.Column<int>(type: "int", nullable: false),
                    Comportamiento = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanificacionHitos",
                schema: "valoracion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPlanificacion = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indicador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Meta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanificacionHitos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanificacionHitos_PlanificacionResultados_IdPlanificacion",
                        column: x => x.IdPlanificacion,
                        principalSchema: "valoracion",
                        principalTable: "PlanificacionResultados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanificacionHitos_IdPlanificacion",
                schema: "valoracion",
                table: "PlanificacionHitos",
                column: "IdPlanificacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Responsabilidades_Objetivos_IdResponsabilidad",
                schema: "valoracion",
                table: "Responsabilidades",
                column: "IdResponsabilidad",
                principalSchema: "valoracion",
                principalTable: "Objetivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responsabilidades_Objetivos_IdResponsabilidad",
                schema: "valoracion",
                table: "Responsabilidades");

            migrationBuilder.DropTable(
                name: "Competencias",
                schema: "valoracion");

            migrationBuilder.DropTable(
                name: "PlanificacionHitos",
                schema: "valoracion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Responsabilidades",
                schema: "valoracion",
                table: "Responsabilidades");

            migrationBuilder.DropColumn(
                name: "TipoObjetivo",
                schema: "valoracion",
                table: "Resultados");

            migrationBuilder.DropColumn(
                name: "DatoManual1",
                schema: "valoracion",
                table: "PlanificacionResultados");

            migrationBuilder.DropColumn(
                name: "DatoManual2",
                schema: "valoracion",
                table: "PlanificacionResultados");

            migrationBuilder.DropColumn(
                name: "DatoManual3",
                schema: "valoracion",
                table: "PlanificacionResultados");

            migrationBuilder.DropColumn(
                name: "IdEstructura",
                schema: "valoracion",
                table: "Responsabilidades");

            migrationBuilder.RenameTable(
                name: "Responsabilidades",
                schema: "valoracion",
                newName: "Responsabilidad");

            migrationBuilder.RenameIndex(
                name: "IX_Responsabilidades_IdResponsabilidad",
                table: "Responsabilidad",
                newName: "IX_Responsabilidad_IdResponsabilidad");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responsabilidad",
                table: "Responsabilidad",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Responsabilidad_Objetivos_IdResponsabilidad",
                table: "Responsabilidad",
                column: "IdResponsabilidad",
                principalSchema: "valoracion",
                principalTable: "Objetivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
