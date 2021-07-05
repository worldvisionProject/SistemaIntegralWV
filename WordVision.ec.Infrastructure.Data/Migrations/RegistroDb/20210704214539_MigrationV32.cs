using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cwbo",
                schema: "planifica",
                table: "EstrategiaNacionales");

            migrationBuilder.DropColumn(
                name: "Programa",
                schema: "planifica",
                table: "EstrategiaNacionales");

            migrationBuilder.AlterColumn<string>(
                name: "Dimension",
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

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                schema: "planifica",
                table: "ObjetivoEstrategicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
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

            migrationBuilder.AddColumn<string>(
                name: "Cwbo",
                schema: "planifica",
                table: "ObjetivoEstrategicos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Programa",
                schema: "planifica",
                table: "ObjetivoEstrategicos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntregableAnual",
                schema: "planifica",
                table: "IndicadorEstrategicos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                schema: "planifica",
                table: "EstrategiaNacionales",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaRegional",
                schema: "planifica",
                table: "EstrategiaNacionales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaNacional",
                schema: "planifica",
                table: "EstrategiaNacionales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                schema: "planifica",
                table: "EstrategiaNacionales",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cwbo",
                schema: "planifica",
                table: "ObjetivoEstrategicos");

            migrationBuilder.DropColumn(
                name: "Programa",
                schema: "planifica",
                table: "ObjetivoEstrategicos");

            migrationBuilder.DropColumn(
                name: "EntregableAnual",
                schema: "planifica",
                table: "IndicadorEstrategicos");

            migrationBuilder.AlterColumn<string>(
                name: "Dimension",
                schema: "planifica",
                table: "ObjetivoEstrategicos",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                schema: "planifica",
                table: "ObjetivoEstrategicos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                schema: "planifica",
                table: "ObjetivoEstrategicos",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);

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
                name: "Nombre",
                schema: "planifica",
                table: "EstrategiaNacionales",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "MetaRegional",
                schema: "planifica",
                table: "EstrategiaNacionales",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MetaNacional",
                schema: "planifica",
                table: "EstrategiaNacionales",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                schema: "planifica",
                table: "EstrategiaNacionales",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);

            migrationBuilder.AddColumn<string>(
                name: "Cwbo",
                schema: "planifica",
                table: "EstrategiaNacionales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Programa",
                schema: "planifica",
                table: "EstrategiaNacionales",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
