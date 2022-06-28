using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class BiosistemasV001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "survey");

            migrationBuilder.CreateTable(
                name: "EncuestadoKobos",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    eko_xform_id_string = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_formhub = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enk_start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    enk_end = table.Column<DateTime>(type: "datetime2", nullable: false),
                    enk_today = table.Column<DateTime>(type: "datetime2", nullable: false),
                    eko_deviceid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_imei = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_secuencial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eko_pa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_canton = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_parroquia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_comunidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_desastre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eko_nombre_encuestador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enk_fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    eko_ref_vivienda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eko_nombre_nino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_patrocinio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eko_status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestadoKobos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EncuestaKobos",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    enk_Id_string = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enk_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enk_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enk_Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enk_Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaKobos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EProgramas",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    pa_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EProgramas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ERegiones",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reg_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ERegiones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreguntaKobos",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prk_CodigoWVE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prk_CodigoKobo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prk_Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prk_Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EncuestaKoboId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreguntaKobos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreguntaKobos_EncuestaKobos_EncuestaKoboId",
                        column: x => x.EncuestaKoboId,
                        principalSchema: "survey",
                        principalTable: "EncuestaKobos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EProvincias",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    pro_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eRegionId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EProvincias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EProvincias_ERegiones_eRegionId",
                        column: x => x.eRegionId,
                        principalSchema: "survey",
                        principalTable: "ERegiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EncuestadoPreguntaKobos",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncuestadoKoboId = table.Column<int>(type: "int", nullable: true),
                    PreguntaKoboId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestadoPreguntaKobos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EncuestadoPreguntaKobos_EncuestadoKobos_EncuestadoKoboId",
                        column: x => x.EncuestadoKoboId,
                        principalSchema: "survey",
                        principalTable: "EncuestadoKobos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EncuestadoPreguntaKobos_PreguntaKobos_PreguntaKoboId",
                        column: x => x.PreguntaKoboId,
                        principalSchema: "survey",
                        principalTable: "PreguntaKobos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ECantones",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    can_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EProvinciaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ECantones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ECantones_EProvincias_EProvinciaId",
                        column: x => x.EProvinciaId,
                        principalSchema: "survey",
                        principalTable: "EProvincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EParroquias",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    par_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EProgramaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ECantonId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EParroquias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EParroquias_ECantones_ECantonId",
                        column: x => x.ECantonId,
                        principalSchema: "survey",
                        principalTable: "ECantones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EParroquias_EProgramas_EProgramaId",
                        column: x => x.EProgramaId,
                        principalSchema: "survey",
                        principalTable: "EProgramas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EComunidades",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    com_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eParroquiaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EComunidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EComunidades_EParroquias_eParroquiaId",
                        column: x => x.eParroquiaId,
                        principalSchema: "survey",
                        principalTable: "EParroquias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ECantones_EProvinciaId",
                schema: "survey",
                table: "ECantones",
                column: "EProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_EComunidades_eParroquiaId",
                schema: "survey",
                table: "EComunidades",
                column: "eParroquiaId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestadoPreguntaKobos_EncuestadoKoboId",
                schema: "survey",
                table: "EncuestadoPreguntaKobos",
                column: "EncuestadoKoboId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestadoPreguntaKobos_PreguntaKoboId",
                schema: "survey",
                table: "EncuestadoPreguntaKobos",
                column: "PreguntaKoboId");

            migrationBuilder.CreateIndex(
                name: "IX_EParroquias_ECantonId",
                schema: "survey",
                table: "EParroquias",
                column: "ECantonId");

            migrationBuilder.CreateIndex(
                name: "IX_EParroquias_EProgramaId",
                schema: "survey",
                table: "EParroquias",
                column: "EProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_EProvincias_eRegionId",
                schema: "survey",
                table: "EProvincias",
                column: "eRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_PreguntaKobos_EncuestaKoboId",
                schema: "survey",
                table: "PreguntaKobos",
                column: "EncuestaKoboId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EComunidades",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "EncuestadoPreguntaKobos",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "EParroquias",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "EncuestadoKobos",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "PreguntaKobos",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "ECantones",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "EProgramas",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "EncuestaKobos",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "EProvincias",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "ERegiones",
                schema: "survey");
        }
    }
}
