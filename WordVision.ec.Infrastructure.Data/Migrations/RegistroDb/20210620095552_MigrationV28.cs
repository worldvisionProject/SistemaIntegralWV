using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "planifica");

            migrationBuilder.CreateTable(
                name: "EstrategiaNacionales",
                schema: "planifica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Causa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaRegional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaNacional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstrategiaNacionales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gestiones",
                schema: "planifica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IdEstrategia = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gestiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gestiones_EstrategiaNacionales_IdEstrategia",
                        column: x => x.IdEstrategia,
                        principalSchema: "planifica",
                        principalTable: "EstrategiaNacionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjetivoEstrategicos",
                schema: "planifica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    AreaPrioridad = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Dimension = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    CargoResponsable = table.Column<int>(type: "int", nullable: false),
                    IdEstrategia = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetivoEstrategicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjetivoEstrategicos_EstrategiaNacionales_IdEstrategia",
                        column: x => x.IdEstrategia,
                        principalSchema: "planifica",
                        principalTable: "EstrategiaNacionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gestiones_IdEstrategia",
                schema: "planifica",
                table: "Gestiones",
                column: "IdEstrategia");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetivoEstrategicos_IdEstrategia",
                schema: "planifica",
                table: "ObjetivoEstrategicos",
                column: "IdEstrategia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gestiones",
                schema: "planifica");

            migrationBuilder.DropTable(
                name: "ObjetivoEstrategicos",
                schema: "planifica");

            migrationBuilder.DropTable(
                name: "EstrategiaNacionales",
                schema: "planifica");
        }
    }
}
