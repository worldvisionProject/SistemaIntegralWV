using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev1
{
    public partial class MigrationV024 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogosSocios",
                schema: "soporte",
                table: "Comunicaciones");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogosSocios",
                schema: "soporte",
                table: "Comunicaciones",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
