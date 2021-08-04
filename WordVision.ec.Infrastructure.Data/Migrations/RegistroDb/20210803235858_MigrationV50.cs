using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV50 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_FechaCantidadRecursos_Recursos_IdRecurso",
            //    schema: "planifica",
            //    table: "FechaCantidadRecursos");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Recursos_Actividades_IdActividad",
            //    schema: "planifica",
            //    table: "Recursos");

            //migrationBuilder.AlterColumn<int>(
            //    name: "IdActividad",
            //    schema: "planifica",
            //    table: "Recursos",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "IdRecurso",
            //    schema: "planifica",
            //    table: "FechaCantidadRecursos",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FactorCritico",
                schema: "planifica",
                table: "EstrategiaNacionales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Indicador",
                schema: "planifica",
                table: "EstrategiaNacionales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_FechaCantidadRecursos_Recursos_IdRecurso",
            //    schema: "planifica",
            //    table: "FechaCantidadRecursos",
            //    column: "IdRecurso",
            //    principalSchema: "planifica",
            //    principalTable: "Recursos",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Recursos_Actividades_IdActividad",
            //    schema: "planifica",
            //    table: "Recursos",
            //    column: "IdActividad",
            //    principalSchema: "planifica",
            //    principalTable: "Actividades",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FechaCantidadRecursos_Recursos_IdRecurso",
                schema: "planifica",
                table: "FechaCantidadRecursos");

            migrationBuilder.DropForeignKey(
                name: "FK_Recursos_Actividades_IdActividad",
                schema: "planifica",
                table: "Recursos");

            migrationBuilder.DropColumn(
                name: "FactorCritico",
                schema: "planifica",
                table: "EstrategiaNacionales");

            migrationBuilder.DropColumn(
                name: "Indicador",
                schema: "planifica",
                table: "EstrategiaNacionales");

            migrationBuilder.AlterColumn<int>(
                name: "IdActividad",
                schema: "planifica",
                table: "Recursos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdRecurso",
                schema: "planifica",
                table: "FechaCantidadRecursos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FechaCantidadRecursos_Recursos_IdRecurso",
                schema: "planifica",
                table: "FechaCantidadRecursos",
                column: "IdRecurso",
                principalSchema: "planifica",
                principalTable: "Recursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recursos_Actividades_IdActividad",
                schema: "planifica",
                table: "Recursos",
                column: "IdActividad",
                principalSchema: "planifica",
                principalTable: "Actividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
