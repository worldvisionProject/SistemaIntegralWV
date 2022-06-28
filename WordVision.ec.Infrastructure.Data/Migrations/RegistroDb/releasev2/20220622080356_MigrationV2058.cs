using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2058 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoPorAnioFiscales",
                schema: "indicador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnioFiscal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdProceso = table.Column<int>(type: "int", nullable: false),
                    IdEstadoAnioFiscal = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoPorAnioFiscales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstadoPorAnioFiscales_DetalleCatalogos_IdEstadoAnioFiscal",
                        column: x => x.IdEstadoAnioFiscal,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EstadoPorAnioFiscales_DetalleCatalogos_IdProceso",
                        column: x => x.IdProceso,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstadoPorAnioFiscales_IdEstadoAnioFiscal",
                schema: "indicador",
                table: "EstadoPorAnioFiscales",
                column: "IdEstadoAnioFiscal");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoPorAnioFiscales_IdProceso",
                schema: "indicador",
                table: "EstadoPorAnioFiscales",
                column: "IdProceso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstadoPorAnioFiscales",
                schema: "indicador");
        }
    }
}
