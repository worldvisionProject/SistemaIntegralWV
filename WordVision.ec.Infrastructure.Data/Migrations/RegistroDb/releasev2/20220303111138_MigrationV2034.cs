using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2034 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LineBase",
                schema: "planifica",
                table: "IndicadorAFs",
                newName: "LineaBase");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LineaBase",
                schema: "planifica",
                table: "IndicadorAFs",
                newName: "LineBase");
        }
    }
}
