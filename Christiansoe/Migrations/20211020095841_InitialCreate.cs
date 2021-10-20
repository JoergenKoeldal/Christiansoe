using Microsoft.EntityFrameworkCore.Migrations;

namespace Christiansoe.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Map",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Map", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BingoBoard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MapId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BingoBoard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BingoBoard_Map_MapId",
                        column: x => x.MapId,
                        principalTable: "Map",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Field",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoundUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BingoBoardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Field_BingoBoard_BingoBoardId",
                        column: x => x.BingoBoardId,
                        principalTable: "BingoBoard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Length = table.Column<double>(type: "float", nullable: false),
                    HikingTime = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BingoBoardId = table.Column<int>(type: "int", nullable: true),
                    MapId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Route_BingoBoard_BingoBoardId",
                        column: x => x.BingoBoardId,
                        principalTable: "BingoBoard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Route_Map_MapId",
                        column: x => x.MapId,
                        principalTable: "Map",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BingoBoard_MapId",
                table: "BingoBoard",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_Field_BingoBoardId",
                table: "Field",
                column: "BingoBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_BingoBoardId",
                table: "Route",
                column: "BingoBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_MapId",
                table: "Route",
                column: "MapId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Field");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "BingoBoard");

            migrationBuilder.DropTable(
                name: "Map");
        }
    }
}
