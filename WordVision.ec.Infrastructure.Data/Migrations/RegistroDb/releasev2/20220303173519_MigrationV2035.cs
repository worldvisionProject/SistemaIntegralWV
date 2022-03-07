using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2035 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoMeta",
                schema: "planifica",
                table: "IndicadorPOAs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoMeta",
                schema: "planifica",
                table: "IndicadorEstrategicos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoMeta",
                schema: "planifica",
                table: "IndicadorPOAs");

            migrationBuilder.DropColumn(
                name: "TipoMeta",
                schema: "planifica",
                table: "IndicadorEstrategicos");
        }
    }
}
