using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class MigrationV3G008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Interaciones",
                schema: "donacion",
                table: "Interaciones",
                newName: "Gestion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gestion",
                schema: "donacion",
                table: "Interaciones",
                newName: "Interaciones");
        }
    }
}
