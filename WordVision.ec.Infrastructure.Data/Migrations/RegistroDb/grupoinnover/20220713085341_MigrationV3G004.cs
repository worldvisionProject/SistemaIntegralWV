using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class MigrationV3G004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "Observacion",
            //    schema: "indicador",
            //    table: "FaseProgramaAreas",
            //    type: "nvarchar(200)",
            //    maxLength: 200,
            //    nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PeriodoDonacion",
                schema: "donacion",
                table: "Donantes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "CalificacionDonante",
                schema: "donacion",
                table: "Donantes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);

            //migrationBuilder.CreateTable(
            //    name: "ProyectoTecnicoPorProgramaAreas",
            //    schema: "indicador",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IdLogFrameIndicadorPR = table.Column<int>(type: "int", nullable: false),
            //        Asignado = table.Column<bool>(type: "bit", nullable: false),
            //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProyectoTecnicoPorProgramaAreas", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ProyectoTecnicoPorProgramaAreas_LogFrameIndicadoresPR_IdLogFrameIndicadorPR",
            //            column: x => x.IdLogFrameIndicadorPR,
            //            principalSchema: "adm",
            //            principalTable: "LogFrameIndicadoresPR",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProyectoTecnicoPorProgramaAreas_IdLogFrameIndicadorPR",
            //    schema: "indicador",
            //    table: "ProyectoTecnicoPorProgramaAreas",
            //    column: "IdLogFrameIndicadorPR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "ProyectoTecnicoPorProgramaAreas",
            //    schema: "indicador");

            //migrationBuilder.DropColumn(
            //    name: "Observacion",
            //    schema: "indicador",
            //    table: "FaseProgramaAreas");

            migrationBuilder.AlterColumn<int>(
                name: "PeriodoDonacion",
                schema: "donacion",
                table: "Donantes",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CalificacionDonante",
                schema: "donacion",
                table: "Donantes",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
