using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class SQLCryptoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cryptos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    crypto_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cryptos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "crypto_images",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    crypto_id = table.Column<int>(type: "int", nullable: false),
                    image_path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crypto_images", x => x.id);
                    table.ForeignKey(
                        name: "FK_crypto_images_cryptos_crypto_id",
                        column: x => x.crypto_id,
                        principalTable: "cryptos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_crypto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    crypto_id = table.Column<int>(type: "int", nullable: false),
                    crypto_url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_crypto", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_crypto_cryptos_crypto_id",
                        column: x => x.crypto_id,
                        principalTable: "cryptos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_crypto_images_crypto_id",
                table: "crypto_images",
                column: "crypto_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_crypto_crypto_id",
                table: "user_crypto",
                column: "crypto_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "crypto_images");

            migrationBuilder.DropTable(
                name: "user_crypto");

            migrationBuilder.DropTable(
                name: "cryptos");
        }
    }
}
