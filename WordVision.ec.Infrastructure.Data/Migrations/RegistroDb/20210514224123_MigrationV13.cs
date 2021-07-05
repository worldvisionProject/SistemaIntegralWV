using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormularioTercero_Formularios_IdFormularioTecero",
                table: "FormularioTercero");

            migrationBuilder.DropForeignKey(
                name: "FK_FormularioTercero_Tercero_IdTeceroFormulario",
                table: "FormularioTercero");

            migrationBuilder.DropIndex(
                name: "IX_FormularioTercero_IdFormularioTecero",
                table: "FormularioTercero");

            migrationBuilder.DropColumn(
                name: "IdFormularioTecero",
                table: "FormularioTercero");

            migrationBuilder.DropColumn(
                name: "IdTercero",
                table: "FormularioTercero");

            migrationBuilder.RenameColumn(
                name: "IdTeceroFormulario",
                table: "FormularioTercero",
                newName: "IdTecero");

            migrationBuilder.RenameIndex(
                name: "IX_FormularioTercero_IdTeceroFormulario",
                table: "FormularioTercero",
                newName: "IX_FormularioTercero_IdTecero");

            migrationBuilder.AlterColumn<int>(
                name: "IdFormulario",
                table: "FormularioTercero",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_FormularioTercero_IdFormulario",
                table: "FormularioTercero",
                column: "IdFormulario");

            migrationBuilder.AddForeignKey(
                name: "FK_FormularioTercero_Formularios_IdFormulario",
                table: "FormularioTercero",
                column: "IdFormulario",
                principalTable: "Formularios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormularioTercero_Tercero_IdTecero",
                table: "FormularioTercero",
                column: "IdTecero",
                principalTable: "Tercero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormularioTercero_Formularios_IdFormulario",
                table: "FormularioTercero");

            migrationBuilder.DropForeignKey(
                name: "FK_FormularioTercero_Tercero_IdTecero",
                table: "FormularioTercero");

            migrationBuilder.DropIndex(
                name: "IX_FormularioTercero_IdFormulario",
                table: "FormularioTercero");

            migrationBuilder.RenameColumn(
                name: "IdTecero",
                table: "FormularioTercero",
                newName: "IdTeceroFormulario");

            migrationBuilder.RenameIndex(
                name: "IX_FormularioTercero_IdTecero",
                table: "FormularioTercero",
                newName: "IX_FormularioTercero_IdTeceroFormulario");

            migrationBuilder.AlterColumn<int>(
                name: "IdFormulario",
                table: "FormularioTercero",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdFormularioTecero",
                table: "FormularioTercero",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdTercero",
                table: "FormularioTercero",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_FormularioTercero_IdFormularioTecero",
                table: "FormularioTercero",
                column: "IdFormularioTecero");

            migrationBuilder.AddForeignKey(
                name: "FK_FormularioTercero_Formularios_IdFormularioTecero",
                table: "FormularioTercero",
                column: "IdFormularioTecero",
                principalTable: "Formularios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormularioTercero_Tercero_IdTeceroFormulario",
                table: "FormularioTercero",
                column: "IdTeceroFormulario",
                principalTable: "Tercero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
