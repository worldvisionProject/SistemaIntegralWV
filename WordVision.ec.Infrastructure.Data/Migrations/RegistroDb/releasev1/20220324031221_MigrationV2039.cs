using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev1
{
    public partial class MigrationV2039 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCumplimiento",
                schema: "valoracion",
                table: "PlanificacionResultados",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PonderacionResultado",
                schema: "valoracion",
                table: "PlanificacionResultados",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeCumplimiento",
                schema: "valoracion",
                table: "PlanificacionResultados",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AvanceObjetivos",
                schema: "valoracion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCumplimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Porcentaje = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComentarioLider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPlanificacion = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvanceObjetivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvanceObjetivos_PlanificacionResultados_IdPlanificacion",
                        column: x => x.IdPlanificacion,
                        principalSchema: "valoracion",
                        principalTable: "PlanificacionResultados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeguimientoObjetivos",
                schema: "valoracion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Ultimo = table.Column<int>(type: "int", nullable: false),
                    IdPlanificacion = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeguimientoObjetivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeguimientoObjetivos_PlanificacionResultados_IdPlanificacion",
                        column: x => x.IdPlanificacion,
                        principalSchema: "valoracion",
                        principalTable: "PlanificacionResultados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvanceObjetivos_IdPlanificacion",
                schema: "valoracion",
                table: "AvanceObjetivos",
                column: "IdPlanificacion");

            migrationBuilder.CreateIndex(
                name: "IX_SeguimientoObjetivos_IdPlanificacion",
                schema: "valoracion",
                table: "SeguimientoObjetivos",
                column: "IdPlanificacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvanceObjetivos",
                schema: "valoracion");

            migrationBuilder.DropTable(
                name: "SeguimientoObjetivos",
                schema: "valoracion");

            migrationBuilder.DropColumn(
                name: "FechaCumplimiento",
                schema: "valoracion",
                table: "PlanificacionResultados");

            migrationBuilder.DropColumn(
                name: "PonderacionResultado",
                schema: "valoracion",
                table: "PlanificacionResultados");

            migrationBuilder.DropColumn(
                name: "PorcentajeCumplimiento",
                schema: "valoracion",
                table: "PlanificacionResultados");
        }
    }
}
