using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev1
{
    public partial class MigrationV023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comunicaciones_LogoSocio_IdComunicacion",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Comunicaciones_Ponentes_IdComunicacion",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.DropIndex(
                name: "IX_Comunicaciones_IdComunicacion",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LogoSocio",
                table: "LogoSocio");

            migrationBuilder.DropColumn(
                name: "IdComunicacion",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.RenameTable(
                name: "LogoSocio",
                newName: "LogoSocios",
                newSchema: "soporte");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogoSocios",
                schema: "soporte",
                table: "LogoSocios",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ponentes_IdComunicacion",
                schema: "soporte",
                table: "Ponentes",
                column: "IdComunicacion");

            migrationBuilder.CreateIndex(
                name: "IX_LogoSocios_IdComunicacion",
                schema: "soporte",
                table: "LogoSocios",
                column: "IdComunicacion");

            migrationBuilder.AddForeignKey(
                name: "FK_LogoSocios_Comunicaciones_IdComunicacion",
                schema: "soporte",
                table: "LogoSocios",
                column: "IdComunicacion",
                principalSchema: "soporte",
                principalTable: "Comunicaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ponentes_Comunicaciones_IdComunicacion",
                schema: "soporte",
                table: "Ponentes",
                column: "IdComunicacion",
                principalSchema: "soporte",
                principalTable: "Comunicaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogoSocios_Comunicaciones_IdComunicacion",
                schema: "soporte",
                table: "LogoSocios");

            migrationBuilder.DropForeignKey(
                name: "FK_Ponentes_Comunicaciones_IdComunicacion",
                schema: "soporte",
                table: "Ponentes");

            migrationBuilder.DropIndex(
                name: "IX_Ponentes_IdComunicacion",
                schema: "soporte",
                table: "Ponentes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LogoSocios",
                schema: "soporte",
                table: "LogoSocios");

            migrationBuilder.DropIndex(
                name: "IX_LogoSocios_IdComunicacion",
                schema: "soporte",
                table: "LogoSocios");

            migrationBuilder.RenameTable(
                name: "LogoSocios",
                schema: "soporte",
                newName: "LogoSocio");

            migrationBuilder.AddColumn<int>(
                name: "IdComunicacion",
                schema: "soporte",
                table: "Comunicaciones",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogoSocio",
                table: "LogoSocio",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comunicaciones_IdComunicacion",
                schema: "soporte",
                table: "Comunicaciones",
                column: "IdComunicacion",
                unique: true,
                filter: "[IdComunicacion] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Comunicaciones_LogoSocio_IdComunicacion",
                schema: "soporte",
                table: "Comunicaciones",
                column: "IdComunicacion",
                principalTable: "LogoSocio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comunicaciones_Ponentes_IdComunicacion",
                schema: "soporte",
                table: "Comunicaciones",
                column: "IdComunicacion",
                principalSchema: "soporte",
                principalTable: "Ponentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
