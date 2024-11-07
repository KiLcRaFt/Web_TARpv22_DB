using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_TARpv22.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantityToKasutajaToode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kasutajad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nimi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perenimi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kasutajad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tooded",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tooded", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KasutajaToode",
                columns: table => new
                {
                    KasutajaId = table.Column<int>(type: "int", nullable: false),
                    ToodeId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Kokku = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KasutajaToode", x => new { x.KasutajaId, x.ToodeId });
                    table.ForeignKey(
                        name: "FK_KasutajaToode_Kasutajad_KasutajaId",
                        column: x => x.KasutajaId,
                        principalTable: "Kasutajad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KasutajaToode_Tooded_ToodeId",
                        column: x => x.ToodeId,
                        principalTable: "Tooded",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KasutajaToode_ToodeId",
                table: "KasutajaToode",
                column: "ToodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KasutajaToode");

            migrationBuilder.DropTable(
                name: "Kasutajad");

            migrationBuilder.DropTable(
                name: "Tooded");
        }
    }
}
