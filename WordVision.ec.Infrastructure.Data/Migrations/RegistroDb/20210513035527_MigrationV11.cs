using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pres");

            migrationBuilder.CreateTable(
                name: "DatosLDRs",
                schema: "pres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    T0 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    T1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    T2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    T3 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    T4 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    T5 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    T6 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    T7 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    T8 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    T9 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FijoEventual = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Ldr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosLDRs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DatosT5s",
                schema: "pres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Cuentasop = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    T2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DescripcionT2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosT5s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Presupuestos",
                schema: "pres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DescripcionT5 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoCargo = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    TodoAnio = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presupuestos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatosLDRs",
                schema: "pres");

            migrationBuilder.DropTable(
                name: "DatosT5s",
                schema: "pres");

            migrationBuilder.DropTable(
                name: "Presupuestos",
                schema: "pres");
        }
    }
}
