using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev1
{
    public partial class MigrationV028 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Colaboradores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Colaboradores");
        }
    }
}
