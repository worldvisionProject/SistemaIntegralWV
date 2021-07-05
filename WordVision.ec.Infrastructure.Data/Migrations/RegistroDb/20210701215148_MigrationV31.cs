using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Causa",
                schema: "planifica",
                table: "EstrategiaNacionales",
                newName: "Programa");

            migrationBuilder.AddColumn<string>(
                name: "Cwbo",
                schema: "planifica",
                table: "EstrategiaNacionales",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cwbo",
                schema: "planifica",
                table: "EstrategiaNacionales");

            migrationBuilder.RenameColumn(
                name: "Programa",
                schema: "planifica",
                table: "EstrategiaNacionales",
                newName: "Causa");
        }
    }
}
