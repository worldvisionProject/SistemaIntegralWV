using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class MigrationV3G003 : Migration
    {
       protected override void Up(MigrationBuilder migrationBuilder)
        {/*
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBaja",
                schema: "donacion",
                table: "Donantes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotivosBaja",
                schema: "donacion",
                table: "Donantes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProyectoITTs",
                schema: "planifica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFaseProgramaArea = table.Column<int>(type: "int", nullable: false),
                    IdLogFrameOutCome = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoITTs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProyectoITTs_FaseProgramaAreas_IdFaseProgramaArea",
                        column: x => x.IdFaseProgramaArea,
                        principalSchema: "indicador",
                        principalTable: "FaseProgramaAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProyectoITTs_LogFrames_IdLogFrameOutCome",
                        column: x => x.IdLogFrameOutCome,
                        principalSchema: "adm",
                        principalTable: "LogFrames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleProyectoITTs",
                schema: "planifica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineBase = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MetaAF1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MetaAF2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MetaAF3 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MetaAF4 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MetaAF5 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MetaAF6 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdLogFrame = table.Column<int>(type: "int", nullable: false),
                    IdProyectoITT = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleProyectoITTs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleProyectoITTs_LogFrames_IdLogFrame",
                        column: x => x.IdLogFrame,
                        principalSchema: "adm",
                        principalTable: "LogFrames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleProyectoITTs_ProyectoITTs_IdProyectoITT",
                        column: x => x.IdProyectoITT,
                        principalSchema: "planifica",
                        principalTable: "ProyectoITTs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProyectoITTs_IdLogFrame",
                schema: "planifica",
                table: "DetalleProyectoITTs",
                column: "IdLogFrame");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProyectoITTs_IdProyectoITT",
                schema: "planifica",
                table: "DetalleProyectoITTs",
                column: "IdProyectoITT");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoITTs_IdFaseProgramaArea",
                schema: "planifica",
                table: "ProyectoITTs",
                column: "IdFaseProgramaArea");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoITTs_IdLogFrameOutCome",
                schema: "planifica",
                table: "ProyectoITTs",
                column: "IdLogFrameOutCome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleProyectoITTs",
                schema: "planifica");

            migrationBuilder.DropTable(
                name: "ProyectoITTs",
                schema: "planifica");

            migrationBuilder.DropColumn(
                name: "FechaBaja",
                schema: "donacion",
                table: "Donantes");

            migrationBuilder.DropColumn(
                name: "MotivosBaja",
                schema: "donacion",
                table: "Donantes");
        */}
    }
}
