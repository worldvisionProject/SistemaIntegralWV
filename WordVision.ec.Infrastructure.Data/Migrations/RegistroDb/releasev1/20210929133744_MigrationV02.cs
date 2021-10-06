using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev1
{
    public partial class MigrationV02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndicadorCicloEstrategico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndicadorCiclo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEstrategia = table.Column<int>(type: "int", nullable: false),
                    IdIndicadorCiclo = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadorCicloEstrategico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicadorCicloEstrategico_EstrategiaNacionales_IdIndicadorCiclo",
                        column: x => x.IdIndicadorCiclo,
                        principalSchema: "planifica",
                        principalTable: "EstrategiaNacionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MetaCicloEstrategico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGestion = table.Column<int>(type: "int", nullable: false),
                    Meta = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdEmpresa = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdIndicadorCicloEstrategico = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaCicloEstrategico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetaCicloEstrategico_IndicadorCicloEstrategico_IdIndicadorCicloEstrategico",
                        column: x => x.IdIndicadorCicloEstrategico,
                        principalTable: "IndicadorCicloEstrategico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorCicloEstrategico_IdIndicadorCiclo",
                table: "IndicadorCicloEstrategico",
                column: "IdIndicadorCiclo");

            migrationBuilder.CreateIndex(
                name: "IX_MetaCicloEstrategico_IdIndicadorCicloEstrategico",
                table: "MetaCicloEstrategico",
                column: "IdIndicadorCicloEstrategico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetaCicloEstrategico");

            migrationBuilder.DropTable(
                name: "IndicadorCicloEstrategico");
        }
    }
}
