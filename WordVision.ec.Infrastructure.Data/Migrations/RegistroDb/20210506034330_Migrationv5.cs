using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class Migrationv5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firmas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdColaborador = table.Column<int>(type: "int", nullable: false),
                    ColaboradoresId = table.Column<int>(type: "int", nullable: true),
                    IdDocumento = table.Column<int>(type: "int", nullable: false),
                    RutaFirma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Firmas_Colaboradores_ColaboradoresId",
                        column: x => x.ColaboradoresId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Respuestas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdColaborador = table.Column<int>(type: "int", nullable: false),
                    ColaboradoresId = table.Column<int>(type: "int", nullable: true),
                    IdDocumento = table.Column<int>(type: "int", nullable: false),
                    IdPregunta = table.Column<int>(type: "int", nullable: false),
                    DescRespuesta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuestas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Respuestas_Colaboradores_ColaboradoresId",
                        column: x => x.ColaboradoresId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Firmas_ColaboradoresId",
                table: "Firmas",
                column: "ColaboradoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_ColaboradoresId",
                table: "Respuestas",
                column: "ColaboradoresId");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Documentos_Colaboradores_IdColaborador",
            //    table: "Documentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Firmas_Colaboradores_ColaboradoresId",
                table: "Firmas");

            migrationBuilder.DropForeignKey(
                name: "FK_Respuestas_Colaboradores_ColaboradoresId",
                table: "Respuestas");

            migrationBuilder.DropIndex(
                name: "IX_Respuestas_ColaboradoresId",
                table: "Respuestas");

            migrationBuilder.DropIndex(
                name: "IX_Firmas_ColaboradoresId",
                table: "Firmas");

            //migrationBuilder.DropIndex(
            //    name: "IX_Documentos_IdColaborador",
            //    table: "Documentos");

            migrationBuilder.DropColumn(
                name: "ColaboradoresId",
                table: "Respuestas");

            migrationBuilder.DropColumn(
                name: "ColaboradoresId",
                table: "Firmas");

            //migrationBuilder.DropColumn(
            //    name: "IdColaborador",
            //    table: "Documentos");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_IdColaborador",
                table: "Respuestas",
                column: "IdColaborador");

            migrationBuilder.CreateIndex(
                name: "IX_Firmas_IdColaborador",
                table: "Firmas",
                column: "IdColaborador");

            migrationBuilder.AddForeignKey(
                name: "FK_Firmas_Colaboradores_IdColaborador",
                table: "Firmas",
                column: "IdColaborador",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Respuestas_Colaboradores_IdColaborador",
                table: "Respuestas",
                column: "IdColaborador",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Firmas_Colaboradores_IdColaborador",
                table: "Firmas");

            migrationBuilder.DropForeignKey(
                name: "FK_Respuestas_Colaboradores_IdColaborador",
                table: "Respuestas");

            migrationBuilder.DropIndex(
                name: "IX_Respuestas_IdColaborador",
                table: "Respuestas");

            migrationBuilder.DropIndex(
                name: "IX_Firmas_IdColaborador",
                table: "Firmas");

            migrationBuilder.AddColumn<int>(
                name: "ColaboradoresId",
                table: "Respuestas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColaboradoresId",
                table: "Firmas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdColaborador",
                table: "Documentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_ColaboradoresId",
                table: "Respuestas",
                column: "ColaboradoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Firmas_ColaboradoresId",
                table: "Firmas",
                column: "ColaboradoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_IdColaborador",
                table: "Documentos",
                column: "IdColaborador");

            migrationBuilder.AddForeignKey(
                name: "FK_Documentos_Colaboradores_IdColaborador",
                table: "Documentos",
                column: "IdColaborador",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Firmas_Colaboradores_ColaboradoresId",
                table: "Firmas",
                column: "ColaboradoresId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Respuestas_Colaboradores_ColaboradoresId",
                table: "Respuestas",
                column: "ColaboradoresId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
