using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Area",
                schema: "pres",
                table: "DatosLDRs",
                type: "nvarchar(550)",
                maxLength: 550,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                schema: "pres",
                table: "DatosLDRs",
                type: "nvarchar(550)",
                maxLength: 550,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombres",
                schema: "pres",
                table: "DatosLDRs",
                type: "nvarchar(550)",
                maxLength: 550,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                schema: "pres",
                table: "DatosLDRs");

            migrationBuilder.DropColumn(
                name: "Cargo",
                schema: "pres",
                table: "DatosLDRs");

            migrationBuilder.DropColumn(
                name: "Nombres",
                schema: "pres",
                table: "DatosLDRs");
        }
    }
}
