using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev1
{
    public partial class MigrationV027 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ComentarioResolucion",
                schema: "soporte",
                table: "Donantes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComentarioResolucion",
                schema: "soporte",
                table: "Donantes");
        }
    }
}
