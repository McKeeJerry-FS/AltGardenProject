using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AltGardenProject.Migrations
{
    /// <inheritdoc />
    public partial class _004_Add_Plants_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    PlantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePlanted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GardenId = table.Column<int>(type: "int", nullable: false),
                    Required_PH = table.Column<int>(type: "int", nullable: false),
                    Required_Temperature = table.Column<int>(type: "int", nullable: false),
                    Required_Humidity = table.Column<int>(type: "int", nullable: false),
                    Required_LightingStrength = table.Column<int>(type: "int", nullable: false),
                    Harvested = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantId);
                    table.ForeignKey(
                        name: "FK_Plants_Gardens_GardenId",
                        column: x => x.GardenId,
                        principalTable: "Gardens",
                        principalColumn: "GardenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plants_GardenId",
                table: "Plants",
                column: "GardenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}
