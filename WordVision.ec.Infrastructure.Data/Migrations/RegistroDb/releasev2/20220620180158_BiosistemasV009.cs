using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class BiosistemasV009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ETabulado",
                newName: "ETabulados",
                newSchema: "survey");

            migrationBuilder.CreateTable(
                name: "EIndicadorUsuarios",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    EIndicadorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EIndicadorUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EIndicadorUsuarios_EIndicadores_EIndicadorId",
                        column: x => x.EIndicadorId,
                        principalSchema: "survey",
                        principalTable: "EIndicadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EIndicadorUsuarios_EIndicadorId",
                schema: "survey",
                table: "EIndicadorUsuarios",
                column: "EIndicadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EIndicadorUsuarios",
                schema: "survey");

            migrationBuilder.RenameTable(
                name: "ETabulados",
                schema: "survey",
                newName: "ETabulado");
        }
    }
}
