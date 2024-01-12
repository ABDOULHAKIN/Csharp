using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPDojo.Migrations
{
    public partial class Samourais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Samourai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Force = table.Column<int>(type: "int", nullable: false),
                    ArmeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samourai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Samourai_Arme_ArmeId",
                        column: x => x.ArmeId,
                        principalTable: "Arme",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Samourai_ArmeId",
                table: "Samourai",
                column: "ArmeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Samourai");
        }
    }
}
