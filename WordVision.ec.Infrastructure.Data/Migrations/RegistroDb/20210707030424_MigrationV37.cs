using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV37 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Gestiones_IdGestion",
                schema: "planifica",
                table: "Productos");

            migrationBuilder.AlterColumn<int>(
                name: "IdGestion",
                schema: "planifica",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AreaPrioridad",
                schema: "planifica",
                table: "ObjetivoEstrategicos",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Anio",
                schema: "planifica",
                table: "IndicadorAFs",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                schema: "planifica",
                table: "Gestiones",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Anio",
                schema: "planifica",
                table: "Gestiones",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Gestiones_IdGestion",
                schema: "planifica",
                table: "Productos",
                column: "IdGestion",
                principalSchema: "planifica",
                principalTable: "Gestiones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Gestiones_IdGestion",
                schema: "planifica",
                table: "Productos");

            migrationBuilder.AlterColumn<int>(
                name: "IdGestion",
                schema: "planifica",
                table: "Productos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AreaPrioridad",
                schema: "planifica",
                table: "ObjetivoEstrategicos",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Anio",
                schema: "planifica",
                table: "IndicadorAFs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                schema: "planifica",
                table: "Gestiones",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Anio",
                schema: "planifica",
                table: "Gestiones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Gestiones_IdGestion",
                schema: "planifica",
                table: "Productos",
                column: "IdGestion",
                principalSchema: "planifica",
                principalTable: "Gestiones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
