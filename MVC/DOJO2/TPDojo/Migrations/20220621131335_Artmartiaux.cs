using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPDojo.Migrations
{
    public partial class Artmartiaux : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtMartial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtMartial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pratiques",
                columns: table => new
                {
                    ArtsMartiauxId = table.Column<int>(type: "int", nullable: false),
                    PratiquantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pratiques", x => new { x.ArtsMartiauxId, x.PratiquantsId });
                    table.ForeignKey(
                        name: "FK_Pratiques_ArtMartial_ArtsMartiauxId",
                        column: x => x.ArtsMartiauxId,
                        principalTable: "ArtMartial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pratiques_Samourai_PratiquantsId",
                        column: x => x.PratiquantsId,
                        principalTable: "Samourai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pratiques_PratiquantsId",
                table: "Pratiques",
                column: "PratiquantsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pratiques");

            migrationBuilder.DropTable(
                name: "ArtMartial");
        }
    }
}
