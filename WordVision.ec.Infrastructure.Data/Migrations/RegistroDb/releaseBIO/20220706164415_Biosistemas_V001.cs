using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releaseBIO
{
    public partial class Biosistemas_V001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ind_proyecto",
                schema: "survey",
                table: "EIndicadores");

            migrationBuilder.RenameColumn(
                name: "rta_proyecto",
                schema: "survey",
                table: "EReporteTabulados",
                newName: "rta_Operacion");

            migrationBuilder.AddColumn<int>(
                name: "pi_Poblacion",
                schema: "survey",
                table: "EProgramaIndicadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EProyectoId",
                schema: "survey",
                table: "EObjetivos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "obj_Activity",
                schema: "survey",
                table: "EObjetivos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "obj_Nivel",
                schema: "survey",
                table: "EObjetivos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "obj_Outcome",
                schema: "survey",
                table: "EObjetivos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "obj_Output",
                schema: "survey",
                table: "EObjetivos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ind_Operacion",
                schema: "survey",
                table: "EIndicadores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EProyectos",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    py_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EProyectos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EObjetivos_EProyectoId",
                schema: "survey",
                table: "EObjetivos",
                column: "EProyectoId");

            migrationBuilder.AddForeignKey(
                name: "FK_EObjetivos_EProyectos_EProyectoId",
                schema: "survey",
                table: "EObjetivos",
                column: "EProyectoId",
                principalSchema: "survey",
                principalTable: "EProyectos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EObjetivos_EProyectos_EProyectoId",
                schema: "survey",
                table: "EObjetivos");

            migrationBuilder.DropTable(
                name: "EProyectos",
                schema: "survey");

            migrationBuilder.DropIndex(
                name: "IX_EObjetivos_EProyectoId",
                schema: "survey",
                table: "EObjetivos");

            migrationBuilder.DropColumn(
                name: "pi_Poblacion",
                schema: "survey",
                table: "EProgramaIndicadores");

            migrationBuilder.DropColumn(
                name: "EProyectoId",
                schema: "survey",
                table: "EObjetivos");

            migrationBuilder.DropColumn(
                name: "obj_Activity",
                schema: "survey",
                table: "EObjetivos");

            migrationBuilder.DropColumn(
                name: "obj_Nivel",
                schema: "survey",
                table: "EObjetivos");

            migrationBuilder.DropColumn(
                name: "obj_Outcome",
                schema: "survey",
                table: "EObjetivos");

            migrationBuilder.DropColumn(
                name: "obj_Output",
                schema: "survey",
                table: "EObjetivos");

            migrationBuilder.DropColumn(
                name: "ind_Operacion",
                schema: "survey",
                table: "EIndicadores");

            migrationBuilder.RenameColumn(
                name: "rta_Operacion",
                schema: "survey",
                table: "EReporteTabulados",
                newName: "rta_proyecto");

            migrationBuilder.AddColumn<string>(
                name: "ind_proyecto",
                schema: "survey",
                table: "EIndicadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
