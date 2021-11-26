using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEmpresa",
                schema: "adm",
                table: "Estructuras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEmpresa",
                schema: "planifica",
                table: "EstrategiaNacionales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Empresas",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<int>(type: "int", nullable: false),
                    PaginaWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FactorCriticoExitos",
                schema: "planifica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactorCritico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdObjetivoEstra = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactorCriticoExitos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactorCriticoExitos_ObjetivoEstrategicos_IdObjetivoEstra",
                        column: x => x.IdObjetivoEstra,
                        principalSchema: "planifica",
                        principalTable: "ObjetivoEstrategicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndicadorEstrategicos",
                schema: "planifica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndicadorResultado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedioVerificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Responsable = table.Column<int>(type: "int", nullable: false),
                    UnidadMedida = table.Column<int>(type: "int", nullable: false),
                    LineaBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Meta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdFactorCritico = table.Column<int>(type: "int", nullable: false),
                    IdIndicaAF = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadorEstrategicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicadorEstrategicos_FactorCriticoExitos_IdFactorCritico",
                        column: x => x.IdFactorCritico,
                        principalSchema: "planifica",
                        principalTable: "FactorCriticoExitos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicadorEstrategicos_IndicadorEstrategicos_IdIndicaAF",
                        column: x => x.IdIndicaAF,
                        principalSchema: "planifica",
                        principalTable: "IndicadorEstrategicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndicadorAFs",
                schema: "planifica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Meta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Entregable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    IdIndicaAF = table.Column<int>(type: "int", nullable: false),
                    IndicadorEstrategicosId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadorAFs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicadorAFs_IndicadorEstrategicos_IndicadorEstrategicosId",
                        column: x => x.IndicadorEstrategicosId,
                        principalSchema: "planifica",
                        principalTable: "IndicadorEstrategicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estructuras_IdEmpresa",
                schema: "adm",
                table: "Estructuras",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_FactorCriticoExitos_IdObjetivoEstra",
                schema: "planifica",
                table: "FactorCriticoExitos",
                column: "IdObjetivoEstra");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorAFs_IndicadorEstrategicosId",
                schema: "planifica",
                table: "IndicadorAFs",
                column: "IndicadorEstrategicosId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorEstrategicos_IdFactorCritico",
                schema: "planifica",
                table: "IndicadorEstrategicos",
                column: "IdFactorCritico");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorEstrategicos_IdIndicaAF",
                schema: "planifica",
                table: "IndicadorEstrategicos",
                column: "IdIndicaAF");

            migrationBuilder.AddForeignKey(
                name: "FK_Estructuras_Empresas_IdEmpresa",
                schema: "adm",
                table: "Estructuras",
                column: "IdEmpresa",
                principalSchema: "adm",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estructuras_Empresas_IdEmpresa",
                schema: "adm",
                table: "Estructuras");

            migrationBuilder.DropTable(
                name: "Empresas",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "IndicadorAFs",
                schema: "planifica");

            migrationBuilder.DropTable(
                name: "IndicadorEstrategicos",
                schema: "planifica");

            migrationBuilder.DropTable(
                name: "FactorCriticoExitos",
                schema: "planifica");

            migrationBuilder.DropIndex(
                name: "IX_Estructuras_IdEmpresa",
                schema: "adm",
                table: "Estructuras");

            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                schema: "adm",
                table: "Estructuras");

            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                schema: "planifica",
                table: "EstrategiaNacionales");
        }
    }
}
