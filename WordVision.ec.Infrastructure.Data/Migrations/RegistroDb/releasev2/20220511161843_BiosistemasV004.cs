using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class BiosistemasV004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EIndicadores_EProgramas_EProgramaId",
                schema: "survey",
                table: "EIndicadores");

            migrationBuilder.DropIndex(
                name: "IX_EIndicadores_EProgramaId",
                schema: "survey",
                table: "EIndicadores");

            migrationBuilder.DropColumn(
                name: "EProgramaId",
                schema: "survey",
                table: "EIndicadores");

            migrationBuilder.CreateTable(
                name: "EProgramaIndicadores",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EProgramaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EIndicadorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EProgramaIndicadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EProgramaIndicadores_EIndicadores_EIndicadorId",
                        column: x => x.EIndicadorId,
                        principalSchema: "survey",
                        principalTable: "EIndicadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EProgramaIndicadores_EProgramas_EProgramaId",
                        column: x => x.EProgramaId,
                        principalSchema: "survey",
                        principalTable: "EProgramas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EProgramaIndicadores_EIndicadorId",
                schema: "survey",
                table: "EProgramaIndicadores",
                column: "EIndicadorId");

            migrationBuilder.CreateIndex(
                name: "IX_EProgramaIndicadores_EProgramaId",
                schema: "survey",
                table: "EProgramaIndicadores",
                column: "EProgramaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EProgramaIndicadores",
                schema: "survey");

            migrationBuilder.AddColumn<string>(
                name: "EProgramaId",
                schema: "survey",
                table: "EIndicadores",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EIndicadores_EProgramaId",
                schema: "survey",
                table: "EIndicadores",
                column: "EProgramaId");

            migrationBuilder.AddForeignKey(
                name: "FK_EIndicadores_EProgramas_EProgramaId",
                schema: "survey",
                table: "EIndicadores",
                column: "EProgramaId",
                principalSchema: "survey",
                principalTable: "EProgramas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
