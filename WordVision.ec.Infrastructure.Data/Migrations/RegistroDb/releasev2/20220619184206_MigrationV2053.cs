using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2053 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogFrameIndicadoresPR",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLogFrame = table.Column<int>(type: "int", nullable: false),
                    IdIndicadorPR = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogFrameIndicadoresPR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogFrameIndicadoresPR_DetalleCatalogos_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogFrameIndicadoresPR_IndicadoresPR_IdIndicadorPR",
                        column: x => x.IdIndicadorPR,
                        principalSchema: "adm",
                        principalTable: "IndicadoresPR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogFrameIndicadoresPR_LogFrames_IdLogFrame",
                        column: x => x.IdLogFrame,
                        principalSchema: "adm",
                        principalTable: "LogFrames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogFrameIndicadoresPR_IdEstado",
                schema: "adm",
                table: "LogFrameIndicadoresPR",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrameIndicadoresPR_IdIndicadorPR",
                schema: "adm",
                table: "LogFrameIndicadoresPR",
                column: "IdIndicadorPR");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrameIndicadoresPR_IdLogFrame",
                schema: "adm",
                table: "LogFrameIndicadoresPR",
                column: "IdLogFrame");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogFrameIndicadoresPR",
                schema: "adm");
        }
    }
}
