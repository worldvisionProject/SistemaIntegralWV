using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class MigrationV3G005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EstadoCourier",
                schema: "donacion",
                table: "Donantes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBaja",
                schema: "donacion",
                table: "Donantes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotivosBaja",
                schema: "donacion",
                table: "Donantes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Interaciones",
                schema: "donacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gestion = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDonante = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interaciones_Donantes_IdDonante",
                        column: x => x.IdDonante,
                        principalSchema: "donacion",
                        principalTable: "Donantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interaciones_IdDonante",
                schema: "donacion",
                table: "Interaciones",
                column: "IdDonante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interaciones",
                schema: "donacion");

            migrationBuilder.DropColumn(
                name: "EstadoCourier",
                schema: "donacion",
                table: "Donantes");

            migrationBuilder.DropColumn(
                name: "FechaBaja",
                schema: "donacion",
                table: "Donantes");

            migrationBuilder.DropColumn(
                name: "MotivosBaja",
                schema: "donacion",
                table: "Donantes");
        }
    }
}
