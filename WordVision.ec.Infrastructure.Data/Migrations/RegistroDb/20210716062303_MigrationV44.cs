using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV44 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MetaEstrategicas_IndicadorEstrategicos_IdIndicadorEstrategico",
                schema: "planifica",
                table: "MetaEstrategicas");

            migrationBuilder.AlterColumn<int>(
                name: "IdIndicadorEstrategico",
                schema: "planifica",
                table: "MetaEstrategicas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdGestion",
                schema: "planifica",
                table: "MetaEstrategicas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_MetaEstrategicas_IndicadorEstrategicos_IdIndicadorEstrategico",
                schema: "planifica",
                table: "MetaEstrategicas",
                column: "IdIndicadorEstrategico",
                principalSchema: "planifica",
                principalTable: "IndicadorEstrategicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MetaEstrategicas_IndicadorEstrategicos_IdIndicadorEstrategico",
                schema: "planifica",
                table: "MetaEstrategicas");

            migrationBuilder.DropColumn(
                name: "IdGestion",
                schema: "planifica",
                table: "MetaEstrategicas");

            migrationBuilder.AlterColumn<int>(
                name: "IdIndicadorEstrategico",
                schema: "planifica",
                table: "MetaEstrategicas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MetaEstrategicas_IndicadorEstrategicos_IdIndicadorEstrategico",
                schema: "planifica",
                table: "MetaEstrategicas",
                column: "IdIndicadorEstrategico",
                principalSchema: "planifica",
                principalTable: "IndicadorEstrategicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
