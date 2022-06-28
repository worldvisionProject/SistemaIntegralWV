using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class BiosistemasV002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "enk_today",
                schema: "survey",
                table: "EncuestadoKobos",
                newName: "eko_today");

            migrationBuilder.RenameColumn(
                name: "enk_start",
                schema: "survey",
                table: "EncuestadoKobos",
                newName: "eko_start");

            migrationBuilder.RenameColumn(
                name: "enk_fecha",
                schema: "survey",
                table: "EncuestadoKobos",
                newName: "eko_fecha");

            migrationBuilder.RenameColumn(
                name: "enk_end",
                schema: "survey",
                table: "EncuestadoKobos",
                newName: "eko_end");

            migrationBuilder.AddColumn<int>(
                name: "EncuestaKoboId",
                schema: "survey",
                table: "EncuestadoKobos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EncuestadoKobos_EncuestaKoboId",
                schema: "survey",
                table: "EncuestadoKobos",
                column: "EncuestaKoboId");

            migrationBuilder.AddForeignKey(
                name: "FK_EncuestadoKobos_EncuestaKobos_EncuestaKoboId",
                schema: "survey",
                table: "EncuestadoKobos",
                column: "EncuestaKoboId",
                principalSchema: "survey",
                principalTable: "EncuestaKobos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EncuestadoKobos_EncuestaKobos_EncuestaKoboId",
                schema: "survey",
                table: "EncuestadoKobos");

            migrationBuilder.DropIndex(
                name: "IX_EncuestadoKobos_EncuestaKoboId",
                schema: "survey",
                table: "EncuestadoKobos");

            migrationBuilder.DropColumn(
                name: "EncuestaKoboId",
                schema: "survey",
                table: "EncuestadoKobos");

            migrationBuilder.RenameColumn(
                name: "eko_today",
                schema: "survey",
                table: "EncuestadoKobos",
                newName: "enk_today");

            migrationBuilder.RenameColumn(
                name: "eko_start",
                schema: "survey",
                table: "EncuestadoKobos",
                newName: "enk_start");

            migrationBuilder.RenameColumn(
                name: "eko_fecha",
                schema: "survey",
                table: "EncuestadoKobos",
                newName: "enk_fecha");

            migrationBuilder.RenameColumn(
                name: "eko_end",
                schema: "survey",
                table: "EncuestadoKobos",
                newName: "enk_end");
        }
    }
}
