using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV49 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_FechaCantidadRecurso_Recurso_IdRecurso",
            //    table: "FechaCantidadRecurso");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Recurso_Actividades_IdActividad",
            //    table: "Recurso");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Recurso",
            //    table: "Recurso");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_FechaCantidadRecurso",
            //    table: "FechaCantidadRecurso");

            //migrationBuilder.RenameTable(
            //    name: "Recurso",
            //    newName: "Recursos",
            //    newSchema: "planifica");

            //migrationBuilder.RenameTable(
            //    name: "FechaCantidadRecurso",
            //    newName: "FechaCantidadRecursos",
            //    newSchema: "planifica");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Recurso_IdActividad",
            //    schema: "planifica",
            //    table: "Recursos",
            //    newName: "IX_Recursos_IdActividad");

            //migrationBuilder.RenameIndex(
            //    name: "IX_FechaCantidadRecurso_IdRecurso",
            //    schema: "planifica",
            //    table: "FechaCantidadRecursos",
            //    newName: "IX_FechaCantidadRecursos_IdRecurso");

            migrationBuilder.CreateTable(
               name: "Recursos",
                schema: "planifica",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   CentroCosto = table.Column<int>(type: "int", nullable: false),
                   CuentaCodigoCC = table.Column<int>(type: "int", nullable: false),
                   CategoriaMercaderia = table.Column<int>(type: "int", nullable: false),
                   Insumo = table.Column<int>(type: "int", nullable: false),
                   ParaqueConsultoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   Gtrm = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                   JustificacionConsultoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                   PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                   Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                   DetalleInsumo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   IdActividad = table.Column<int>(type: "int", nullable: true),
                   CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                   LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Recurso", x => x.Id);
                   table.ForeignKey(
                       name: "FK_Recurso_Actividades_IdActividad",
                       column: x => x.IdActividad,
                       principalSchema: "planifica",
                       principalTable: "Actividades",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Restrict);
               });

            migrationBuilder.CreateTable(
                name: "FechaCantidadRecursos",
                  schema: "planifica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdRecurso = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FechaCantidadRecurso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FechaCantidadRecurso_Recurso_IdRecurso",
                        column: x => x.IdRecurso, principalSchema: "planifica",
                        principalTable: "Recursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FechaCantidadRecursos_IdRecurso",
                table: "FechaCantidadRecursos",
                 schema: "planifica",
                column: "IdRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_Recurso_IdActividad",
                table: "Recursos",
                 schema: "planifica",
                column: "IdActividad");

            migrationBuilder.AlterColumn<int>(
                name: "Dimension",
                schema: "planifica",
                table: "ObjetivoEstrategicos",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<int>(
                name: "Categoria",
                schema: "planifica",
                table: "ObjetivoEstrategicos",
                type: "int",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<int>(
                name: "AreaPrioridad",
                schema: "planifica",
                table: "ObjetivoEstrategicos",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1,
                oldNullable: true);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_Recursos",
            //    schema: "planifica",
            //    table: "Recursos",
            //    column: "Id");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_FechaCantidadRecursos",
            //    schema: "planifica",
            //    table: "FechaCantidadRecursos",
            //    column: "Id");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recursos",
                schema: "planifica",
                table: "Recursos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FechaCantidadRecursos",
                schema: "planifica",
                table: "FechaCantidadRecursos");

            migrationBuilder.RenameTable(
                name: "Recursos",
                schema: "planifica",
                newName: "Recurso");

            migrationBuilder.RenameTable(
                name: "FechaCantidadRecursos",
                schema: "planifica",
                newName: "FechaCantidadRecurso");

            migrationBuilder.RenameIndex(
                name: "IX_Recursos_IdActividad",
                table: "Recurso",
                newName: "IX_Recurso_IdActividad");

            migrationBuilder.RenameIndex(
                name: "IX_FechaCantidadRecursos_IdRecurso",
                table: "FechaCantidadRecurso",
                newName: "IX_FechaCantidadRecurso_IdRecurso");

            migrationBuilder.AlterColumn<string>(
                name: "Dimension",
                schema: "planifica",
                table: "ObjetivoEstrategicos",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                schema: "planifica",
                table: "ObjetivoEstrategicos",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "AreaPrioridad",
                schema: "planifica",
                table: "ObjetivoEstrategicos",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recurso",
                table: "Recurso",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FechaCantidadRecurso",
                table: "FechaCantidadRecurso",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FechaCantidadRecurso_Recurso_IdRecurso",
                table: "FechaCantidadRecurso",
                column: "IdRecurso",
                principalTable: "Recurso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recurso_Actividades_IdActividad",
                table: "Recurso",
                column: "IdActividad",
                principalSchema: "planifica",
                principalTable: "Actividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
