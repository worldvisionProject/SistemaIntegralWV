using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProducto",
                schema: "planifica",
                table: "IndicadorEstrategicos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Metas",
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
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                schema: "planifica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdObjetivoEstra = table.Column<int>(type: "int", nullable: false),
                    IdIndicadorEstrategico = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCargoResponsable = table.Column<int>(type: "int", nullable: false),
                    ObjetivoEstrategicosId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_ObjetivoEstrategicos_ObjetivoEstrategicosId",
                        column: x => x.ObjetivoEstrategicosId,
                        principalSchema: "planifica",
                        principalTable: "ObjetivoEstrategicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndicadorPOAs",
                schema: "planifica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndicadorProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedioVerificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Responsable = table.Column<int>(type: "int", nullable: false),
                    UnidadMedida = table.Column<int>(type: "int", nullable: false),
                    LineaBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Meta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    ProductosId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadorPOAs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicadorPOAs_Productos_ProductosId",
                        column: x => x.ProductosId,
                        principalSchema: "planifica",
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Actividades",
                schema: "planifica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionActividad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Entregable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCargoResponsable = table.Column<int>(type: "int", nullable: false),
                    Plazo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TechoPresupuestoCC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ponderacion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdIndicadorPOA = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actividades_IndicadorPOAs_IdIndicadorPOA",
                        column: x => x.IdIndicadorPOA,
                        principalSchema: "planifica",
                        principalTable: "IndicadorPOAs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorEstrategicos_IdProducto",
                schema: "planifica",
                table: "IndicadorEstrategicos",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_IdIndicadorPOA",
                schema: "planifica",
                table: "Actividades",
                column: "IdIndicadorPOA");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorPOAs_ProductosId",
                schema: "planifica",
                table: "IndicadorPOAs",
                column: "ProductosId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ObjetivoEstrategicosId",
                schema: "planifica",
                table: "Productos",
                column: "ObjetivoEstrategicosId");

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorEstrategicos_Productos_IdProducto",
                schema: "planifica",
                table: "IndicadorEstrategicos",
                column: "IdProducto",
                principalSchema: "planifica",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorEstrategicos_Productos_IdProducto",
                schema: "planifica",
                table: "IndicadorEstrategicos");

            migrationBuilder.DropTable(
                name: "Actividades",
                schema: "planifica");

            migrationBuilder.DropTable(
                name: "Metas",
                schema: "planifica");

            migrationBuilder.DropTable(
                name: "IndicadorPOAs",
                schema: "planifica");

            migrationBuilder.DropTable(
                name: "Productos",
                schema: "planifica");

            migrationBuilder.DropIndex(
                name: "IX_IndicadorEstrategicos_IdProducto",
                schema: "planifica",
                table: "IndicadorEstrategicos");

            migrationBuilder.DropColumn(
                name: "IdProducto",
                schema: "planifica",
                table: "IndicadorEstrategicos");
        }
    }
}
