using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2050 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogFrames_IndicadoresPR_IdIndicadorPR",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropIndex(
                name: "IX_LogFrames_IdIndicadorPR",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.DropColumn(
                name: "IdIndicadorPR",
                schema: "adm",
                table: "LogFrames");

            migrationBuilder.CreateTable(
                name: "LogFrameIndicadoresPR",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogFrameId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogFrameIndicadoresPR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogFrameIndicadoresPR_LogFrames_LogFrameId",
                        column: x => x.LogFrameId,
                        principalSchema: "adm",
                        principalTable: "LogFrames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogFrameIndicadoresPR_LogFrameId",
                schema: "adm",
                table: "LogFrameIndicadoresPR",
                column: "LogFrameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogFrameIndicadoresPR",
                schema: "adm");

            migrationBuilder.AddColumn<int>(
                name: "IdIndicadorPR",
                schema: "adm",
                table: "LogFrames",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogFrames_IdIndicadorPR",
                schema: "adm",
                table: "LogFrames",
                column: "IdIndicadorPR");

            migrationBuilder.AddForeignKey(
                name: "FK_LogFrames_IndicadoresPR_IdIndicadorPR",
                schema: "adm",
                table: "LogFrames",
                column: "IdIndicadorPR",
                principalSchema: "adm",
                principalTable: "IndicadoresPR",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
