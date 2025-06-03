using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "plantspecies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    latin_name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    is_protected = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plantspecies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "zones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    area_ha = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zones", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "facilities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zone_id = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    condition = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "good"),
                    installed_on = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facilities", x => x.id);
                    table.ForeignKey(
                        name: "FK_facilities_zones_zone_id",
                        column: x => x.zone_id,
                        principalTable: "zones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "zoneplants",
                columns: table => new
                {
                    zone_id = table.Column<int>(type: "int", nullable: false),
                    plant_id = table.Column<int>(type: "int", nullable: false),
                    density = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zoneplants", x => new { x.zone_id, x.plant_id });
                    table.CheckConstraint("ck_zoneplant_density", "density IN ('rare','medium','common')");
                    table.ForeignKey(
                        name: "FK_zoneplants_plantspecies_plant_id",
                        column: x => x.plant_id,
                        principalTable: "plantspecies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_zoneplants_zones_zone_id",
                        column: x => x.zone_id,
                        principalTable: "zones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_facilities_zone_id",
                table: "facilities",
                column: "zone_id");

            migrationBuilder.CreateIndex(
                name: "IX_plantspecies_latin_name",
                table: "plantspecies",
                column: "latin_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_plantspecies_name",
                table: "plantspecies",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_zoneplants_plant_id",
                table: "zoneplants",
                column: "plant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "facilities");

            migrationBuilder.DropTable(
                name: "zoneplants");

            migrationBuilder.DropTable(
                name: "plantspecies");

            migrationBuilder.DropTable(
                name: "zones");
        }
    }
}
