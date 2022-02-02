using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MetaAcumulada",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetaAcumulada",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");
        }
    }
}
