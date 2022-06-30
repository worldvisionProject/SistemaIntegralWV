using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class MigrationV3G001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "donacion");

            migrationBuilder.RenameTable(
                name: "Donantes",
                schema: "soporte",
                newName: "Donantes",
                newSchema: "donacion");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                schema: "adm",
                table: "Ciudades",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "CodigoArea",
                schema: "adm",
                table: "Ciudades",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cantidad",
                schema: "donacion",
                table: "Donantes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hubspot",
                schema: "donacion",
                table: "Donantes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BancosCompanias",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CuentaContable = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BancosCompanias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodigoSCIs",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreBanco = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CodigoBanco = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EstadoBanco = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigoSCIs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodigoSCIs_Empresas_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalSchema: "adm",
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Debitos",
                schema: "donacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoBanco = table.Column<int>(type: "int", nullable: false),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Quincena = table.Column<int>(type: "int", nullable: false),
                    Intento = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CodigoRespuesta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: true),
                    IdDonante = table.Column<int>(type: "int", nullable: false),
                    FormaPago = table.Column<int>(type: "int", nullable: false),
                    Contrapartida = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaDebito = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debitos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debitos_Donantes_IdDonante",
                        column: x => x.IdDonante,
                        principalSchema: "donacion",
                        principalTable: "Donantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoDonantes",
                schema: "donacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    IdDonante = table.Column<int>(type: "int", nullable: false),
                    FormaPago = table.Column<int>(type: "int", nullable: false),
                    NumReferencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoCuenta = table.Column<int>(type: "int", nullable: true),
                    NumeroCuenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TiposTarjetasCredito = table.Column<int>(type: "int", nullable: true),
                    NumeroTarjeta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCaducidad = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Banco = table.Column<int>(type: "int", nullable: true),
                    NumReferenciaBp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoCuentaBp = table.Column<int>(type: "int", nullable: true),
                    NumeroCuentaBp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TiposTarjetasCreditoBp = table.Column<int>(type: "int", nullable: true),
                    NumeroTarjetaBp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCaducidadBp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BancoBp = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoDonantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoDonantes_Donantes_IdDonante",
                        column: x => x.IdDonante,
                        principalSchema: "donacion",
                        principalTable: "Donantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CodigoSCIs_IdEmpresa",
                schema: "adm",
                table: "CodigoSCIs",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Debitos_IdDonante",
                schema: "donacion",
                table: "Debitos",
                column: "IdDonante");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoDonantes_IdDonante",
                schema: "donacion",
                table: "ProductoDonantes",
                column: "IdDonante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BancosCompanias",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "CodigoSCIs",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "Debitos",
                schema: "donacion");

            migrationBuilder.DropTable(
                name: "ProductoDonantes",
                schema: "donacion");

            migrationBuilder.DropColumn(
                name: "CodigoArea",
                schema: "adm",
                table: "Ciudades");

            migrationBuilder.DropColumn(
                name: "Hubspot",
                schema: "donacion",
                table: "Donantes");

            migrationBuilder.RenameTable(
                name: "Donantes",
                schema: "donacion",
                newName: "Donantes",
                newSchema: "soporte");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                schema: "adm",
                table: "Ciudades",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cantidad",
                schema: "soporte",
                table: "Donantes",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
