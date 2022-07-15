using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class MigrationV3G007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interaciones_Donantes_IdDonante",
                schema: "donacion",
                table: "Interaciones");

            migrationBuilder.AlterColumn<int>(
                name: "IdDonante",
                schema: "donacion",
                table: "Interaciones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Interaciones_Donantes_IdDonante",
                schema: "donacion",
                table: "Interaciones",
                column: "IdDonante",
                principalSchema: "donacion",
                principalTable: "Donantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interaciones_Donantes_IdDonante",
                schema: "donacion",
                table: "Interaciones");

            migrationBuilder.AlterColumn<int>(
                name: "IdDonante",
                schema: "donacion",
                table: "Interaciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Interaciones_Donantes_IdDonante",
                schema: "donacion",
                table: "Interaciones",
                column: "IdDonante",
                principalSchema: "donacion",
                principalTable: "Donantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
