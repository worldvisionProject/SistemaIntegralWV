using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev1
{
    public partial class MigrationV030 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActorParticipante",
                schema: "planifica",
                table: "IndicadorProductoObjetivos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CodigoIndicador",
                schema: "planifica",
                table: "IndicadorProductoObjetivos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEstrategia",
                schema: "planifica",
                table: "IndicadorProductoObjetivos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoIndicador",
                schema: "planifica",
                table: "IndicadorProductoObjetivos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnidadMedida",
                schema: "planifica",
                table: "IndicadorProductoObjetivos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ActorParticipante",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CodigoIndicador",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoIndicador",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnidadMedida",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActorParticipante",
                schema: "planifica",
                table: "IndicadorProductoObjetivos");

            migrationBuilder.DropColumn(
                name: "CodigoIndicador",
                schema: "planifica",
                table: "IndicadorProductoObjetivos");

            migrationBuilder.DropColumn(
                name: "IdEstrategia",
                schema: "planifica",
                table: "IndicadorProductoObjetivos");

            migrationBuilder.DropColumn(
                name: "TipoIndicador",
                schema: "planifica",
                table: "IndicadorProductoObjetivos");

            migrationBuilder.DropColumn(
                name: "UnidadMedida",
                schema: "planifica",
                table: "IndicadorProductoObjetivos");

            migrationBuilder.DropColumn(
                name: "ActorParticipante",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.DropColumn(
                name: "CodigoIndicador",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.DropColumn(
                name: "TipoIndicador",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.DropColumn(
                name: "UnidadMedida",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");
        }
    }
}
