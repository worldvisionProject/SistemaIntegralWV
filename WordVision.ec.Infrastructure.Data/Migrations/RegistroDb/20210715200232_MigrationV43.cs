using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV43 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Metas",
                schema: "planifica");

            migrationBuilder.CreateTable(
                name: "MetaEstrategicas",
                schema: "planifica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumMeses = table.Column<int>(type: "int", nullable: false),
                    Enero = table.Column<bool>(type: "bit", nullable: true),
                    Febrero = table.Column<bool>(type: "bit", nullable: true),
                    Marzo = table.Column<bool>(type: "bit", nullable: true),
                    Abril = table.Column<bool>(type: "bit", nullable: true),
                    Mayo = table.Column<bool>(type: "bit", nullable: true),
                    Junio = table.Column<bool>(type: "bit", nullable: true),
                    Julio = table.Column<bool>(type: "bit", nullable: true),
                    Agosto = table.Column<bool>(type: "bit", nullable: true),
                    Septiembre = table.Column<bool>(type: "bit", nullable: true),
                    Octubre = table.Column<bool>(type: "bit", nullable: true),
                    Noviembre = table.Column<bool>(type: "bit", nullable: true),
                    Diciembre = table.Column<bool>(type: "bit", nullable: true),
                    TipoMedida = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdIndicadorEstrategico = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaEstrategicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetaEstrategicas_IndicadorEstrategicos_IdIndicadorEstrategico",
                        column: x => x.IdIndicadorEstrategico,
                        principalSchema: "planifica",
                        principalTable: "IndicadorEstrategicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MetaTacticas",
                schema: "planifica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumMeses = table.Column<int>(type: "int", nullable: false),
                    Enero = table.Column<bool>(type: "bit", nullable: true),
                    Febrero = table.Column<bool>(type: "bit", nullable: true),
                    Marzo = table.Column<bool>(type: "bit", nullable: true),
                    Abril = table.Column<bool>(type: "bit", nullable: true),
                    Mayo = table.Column<bool>(type: "bit", nullable: true),
                    Junio = table.Column<bool>(type: "bit", nullable: true),
                    Julio = table.Column<bool>(type: "bit", nullable: true),
                    Agosto = table.Column<bool>(type: "bit", nullable: true),
                    Septiembre = table.Column<bool>(type: "bit", nullable: true),
                    Octubre = table.Column<bool>(type: "bit", nullable: true),
                    Noviembre = table.Column<bool>(type: "bit", nullable: true),
                    Diciembre = table.Column<bool>(type: "bit", nullable: true),
                    TipoMedida = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdIndicadorPOA = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaTacticas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetaTacticas_IndicadorPOAs_IdIndicadorPOA",
                        column: x => x.IdIndicadorPOA,
                        principalSchema: "planifica",
                        principalTable: "IndicadorPOAs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MetaEstrategicas_IdIndicadorEstrategico",
                schema: "planifica",
                table: "MetaEstrategicas",
                column: "IdIndicadorEstrategico");

            migrationBuilder.CreateIndex(
                name: "IX_MetaTacticas_IdIndicadorPOA",
                schema: "planifica",
                table: "MetaTacticas",
                column: "IdIndicadorPOA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetaEstrategicas",
                schema: "planifica");

            migrationBuilder.DropTable(
                name: "MetaTacticas",
                schema: "planifica");

            migrationBuilder.CreateTable(
                name: "Metas",
                schema: "planifica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abril = table.Column<bool>(type: "bit", nullable: true),
                    Agosto = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diciembre = table.Column<bool>(type: "bit", nullable: true),
                    Enero = table.Column<bool>(type: "bit", nullable: true),
                    Febrero = table.Column<bool>(type: "bit", nullable: true),
                    Julio = table.Column<bool>(type: "bit", nullable: true),
                    Junio = table.Column<bool>(type: "bit", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Marzo = table.Column<bool>(type: "bit", nullable: true),
                    Mayo = table.Column<bool>(type: "bit", nullable: true),
                    Noviembre = table.Column<bool>(type: "bit", nullable: true),
                    NumMeses = table.Column<int>(type: "int", nullable: false),
                    Octubre = table.Column<bool>(type: "bit", nullable: true),
                    Septiembre = table.Column<bool>(type: "bit", nullable: true),
                    TipoMedida = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metas", x => x.Id);
                });
        }
    }
}
