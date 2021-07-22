using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV45 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MetaTacticas_IndicadorPOAs_IdIndicadorPOA",
                schema: "planifica",
                table: "MetaTacticas");

            migrationBuilder.AlterColumn<int>(
                name: "IdIndicadorPOA",
                schema: "planifica",
                table: "MetaTacticas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Entregable",
                schema: "planifica",
                table: "MetaTacticas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Entregable",
                schema: "planifica",
                table: "MetaEstrategicas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MetaTacticas_IndicadorPOAs_IdIndicadorPOA",
                schema: "planifica",
                table: "MetaTacticas",
                column: "IdIndicadorPOA",
                principalSchema: "planifica",
                principalTable: "IndicadorPOAs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MetaTacticas_IndicadorPOAs_IdIndicadorPOA",
                schema: "planifica",
                table: "MetaTacticas");

            migrationBuilder.DropColumn(
                name: "Entregable",
                schema: "planifica",
                table: "MetaTacticas");

            migrationBuilder.DropColumn(
                name: "Entregable",
                schema: "planifica",
                table: "MetaEstrategicas");

            migrationBuilder.AlterColumn<int>(
                name: "IdIndicadorPOA",
                schema: "planifica",
                table: "MetaTacticas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MetaTacticas_IndicadorPOAs_IdIndicadorPOA",
                schema: "planifica",
                table: "MetaTacticas",
                column: "IdIndicadorPOA",
                principalSchema: "planifica",
                principalTable: "IndicadorPOAs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
