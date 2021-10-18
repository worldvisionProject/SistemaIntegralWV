using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev1
{
    public partial class MigrationV08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitudes_Comunicacion_IdSolicitud",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitudes_Mensajeria_IdSolicitud",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mensajeria",
                table: "Mensajeria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comunicacion",
                table: "Comunicacion");

            migrationBuilder.RenameTable(
                name: "Mensajeria",
                newName: "Mensajerias",
                newSchema: "soporte");

            migrationBuilder.RenameTable(
                name: "Comunicacion",
                newName: "Comunicaciones",
                newSchema: "soporte");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mensajerias",
                schema: "soporte",
                table: "Mensajerias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comunicaciones",
                schema: "soporte",
                table: "Comunicaciones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitudes_Comunicaciones_IdSolicitud",
                schema: "soporte",
                table: "Solicitudes",
                column: "IdSolicitud",
                principalSchema: "soporte",
                principalTable: "Comunicaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitudes_Mensajerias_IdSolicitud",
                schema: "soporte",
                table: "Solicitudes",
                column: "IdSolicitud",
                principalSchema: "soporte",
                principalTable: "Mensajerias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitudes_Comunicaciones_IdSolicitud",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitudes_Mensajerias_IdSolicitud",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mensajerias",
                schema: "soporte",
                table: "Mensajerias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comunicaciones",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.RenameTable(
                name: "Mensajerias",
                schema: "soporte",
                newName: "Mensajeria");

            migrationBuilder.RenameTable(
                name: "Comunicaciones",
                schema: "soporte",
                newName: "Comunicacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mensajeria",
                table: "Mensajeria",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comunicacion",
                table: "Comunicacion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitudes_Comunicacion_IdSolicitud",
                schema: "soporte",
                table: "Solicitudes",
                column: "IdSolicitud",
                principalTable: "Comunicacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitudes_Mensajeria_IdSolicitud",
                schema: "soporte",
                table: "Solicitudes",
                column: "IdSolicitud",
                principalTable: "Mensajeria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
