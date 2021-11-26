using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV48 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TechoPresupuestoCC",
                schema: "planifica",
                table: "Actividades",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "SNPresupuesto",
                schema: "planifica",
                table: "Actividades",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Recurso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CentroCosto = table.Column<int>(type: "int", nullable: false),
                    CuentaCodigoCC = table.Column<int>(type: "int", nullable: false),
                    CategoriaMercaderia = table.Column<int>(type: "int", nullable: false),
                    Insumo = table.Column<int>(type: "int", nullable: false),
                    ParaqueConsultoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gtrm = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    JustificacionConsultoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DetalleInsumo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdActividad = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recurso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recurso_Actividades_IdActividad",
                        column: x => x.IdActividad,
                        principalSchema: "planifica",
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FechaCantidadRecurso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdRecurso = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FechaCantidadRecurso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FechaCantidadRecurso_Recurso_IdRecurso",
                        column: x => x.IdRecurso,
                        principalTable: "Recurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FechaCantidadRecurso_IdRecurso",
                table: "FechaCantidadRecurso",
                column: "IdRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_Recurso_IdActividad",
                table: "Recurso",
                column: "IdActividad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FechaCantidadRecurso");

            migrationBuilder.DropTable(
                name: "Recurso");

            migrationBuilder.DropColumn(
                name: "SNPresupuesto",
                schema: "planifica",
                table: "Actividades");

            migrationBuilder.AlterColumn<decimal>(
                name: "TechoPresupuestoCC",
                schema: "planifica",
                table: "Actividades",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}
