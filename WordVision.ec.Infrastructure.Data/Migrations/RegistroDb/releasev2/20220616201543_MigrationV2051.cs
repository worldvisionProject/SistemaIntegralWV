using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2051 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogFrameIndicadoresPR_LogFrames_LogFrameId",
                schema: "adm",
                table: "LogFrameIndicadoresPR");

            migrationBuilder.DropIndex(
                name: "IX_LogFrameIndicadoresPR_LogFrameId",
                schema: "adm",
                table: "LogFrameIndicadoresPR");

            migrationBuilder.DropColumn(
                name: "LogFrameId",
                schema: "adm",
                table: "LogFrameIndicadoresPR");

            migrationBuilder.AddColumn<int>(
                name: "IdIndicadorPR",
                schema: "adm",
                table: "LogFrameIndicadoresPR",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdLogFrame",
                schema: "adm",
                table: "LogFrameIndicadoresPR",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_LogFrameIndicadoresPR_IndicadoresPR_IdIndicadorPR",
                schema: "adm",
                table: "LogFrameIndicadoresPR",
                column: "IdIndicadorPR",
                principalSchema: "adm",
                principalTable: "IndicadoresPR",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogFrameIndicadoresPR_LogFrames_IdLogFrame",
                schema: "adm",
                table: "LogFrameIndicadoresPR",
                column: "IdLogFrame",
                principalSchema: "adm",
                principalTable: "LogFrames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogFrameIndicadoresPR_IndicadoresPR_IdIndicadorPR",
                schema: "adm",
                table: "LogFrameIndicadoresPR");

            migrationBuilder.DropForeignKey(
                name: "FK_LogFrameIndicadoresPR_LogFrames_IdLogFrame",
                schema: "adm",
                table: "LogFrameIndicadoresPR");

            migrationBuilder.DropIndex(
                name: "IX_LogFrameIndicadoresPR_IdIndicadorPR",
                schema: "adm",
                table: "LogFrameIndicadoresPR");

            migrationBuilder.DropIndex(
                name: "IX_LogFrameIndicadoresPR_IdLogFrame",
                schema: "adm",
                table: "LogFrameIndicadoresPR");

            migrationBuilder.DropColumn(
                name: "IdIndicadorPR",
                schema: "adm",
                table: "LogFrameIndicadoresPR");

            migrationBuilder.DropColumn(
                name: "IdLogFrame",
                schema: "adm",
                table: "LogFrameIndicadoresPR");

            migrationBuilder.AddColumn<int>(
                name: "LogFrameId",
                schema: "adm",
                table: "LogFrameIndicadoresPR",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogFrameIndicadoresPR_LogFrameId",
                schema: "adm",
                table: "LogFrameIndicadoresPR",
                column: "LogFrameId");

            migrationBuilder.AddForeignKey(
                name: "FK_LogFrameIndicadoresPR_LogFrames_LogFrameId",
                schema: "adm",
                table: "LogFrameIndicadoresPR",
                column: "LogFrameId",
                principalSchema: "adm",
                principalTable: "LogFrames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
