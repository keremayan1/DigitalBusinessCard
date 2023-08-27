using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class SQLCryptoDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_crypto_images_cryptos_crypto_id",
                table: "crypto_images");

            migrationBuilder.DropForeignKey(
                name: "FK_user_crypto_cryptos_crypto_id",
                table: "user_crypto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cryptos",
                table: "cryptos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_crypto",
                table: "user_crypto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_crypto_images",
                table: "crypto_images");

            migrationBuilder.RenameTable(
                name: "cryptos",
                newName: "Cryptos");

            migrationBuilder.RenameTable(
                name: "user_crypto",
                newName: "UserCrypto");

            migrationBuilder.RenameTable(
                name: "crypto_images",
                newName: "CryptoImages");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Cryptos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "crypto_name",
                table: "Cryptos",
                newName: "CryptoName");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "UserCrypto",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "crypto_url",
                table: "UserCrypto",
                newName: "CryptoUrl");

            migrationBuilder.RenameColumn(
                name: "crypto_id",
                table: "UserCrypto",
                newName: "CryptoId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UserCrypto",
                newName: "Id)");

            migrationBuilder.RenameIndex(
                name: "IX_user_crypto_crypto_id",
                table: "UserCrypto",
                newName: "IX_UserCrypto_CryptoId");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "CryptoImages",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CryptoImages",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "image_path",
                table: "CryptoImages",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "crypto_id",
                table: "CryptoImages",
                newName: "CryptoId");

            migrationBuilder.RenameIndex(
                name: "IX_crypto_images_crypto_id",
                table: "CryptoImages",
                newName: "IX_CryptoImages_CryptoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cryptos",
                table: "Cryptos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCrypto",
                table: "UserCrypto",
                column: "Id)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CryptoImages",
                table: "CryptoImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CryptoImages_Cryptos_CryptoId",
                table: "CryptoImages",
                column: "CryptoId",
                principalTable: "Cryptos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCrypto_Cryptos_CryptoId",
                table: "UserCrypto",
                column: "CryptoId",
                principalTable: "Cryptos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CryptoImages_Cryptos_CryptoId",
                table: "CryptoImages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCrypto_Cryptos_CryptoId",
                table: "UserCrypto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cryptos",
                table: "Cryptos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCrypto",
                table: "UserCrypto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CryptoImages",
                table: "CryptoImages");

            migrationBuilder.RenameTable(
                name: "Cryptos",
                newName: "cryptos");

            migrationBuilder.RenameTable(
                name: "UserCrypto",
                newName: "user_crypto");

            migrationBuilder.RenameTable(
                name: "CryptoImages",
                newName: "crypto_images");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "cryptos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CryptoName",
                table: "cryptos",
                newName: "crypto_name");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_crypto",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "CryptoUrl",
                table: "user_crypto",
                newName: "crypto_url");

            migrationBuilder.RenameColumn(
                name: "CryptoId",
                table: "user_crypto",
                newName: "crypto_id");

            migrationBuilder.RenameColumn(
                name: "Id)",
                table: "user_crypto",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_UserCrypto_CryptoId",
                table: "user_crypto",
                newName: "IX_user_crypto_crypto_id");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "crypto_images",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "crypto_images",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "crypto_images",
                newName: "image_path");

            migrationBuilder.RenameColumn(
                name: "CryptoId",
                table: "crypto_images",
                newName: "crypto_id");

            migrationBuilder.RenameIndex(
                name: "IX_CryptoImages_CryptoId",
                table: "crypto_images",
                newName: "IX_crypto_images_crypto_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cryptos",
                table: "cryptos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_crypto",
                table: "user_crypto",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_crypto_images",
                table: "crypto_images",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_crypto_images_cryptos_crypto_id",
                table: "crypto_images",
                column: "crypto_id",
                principalTable: "cryptos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_crypto_cryptos_crypto_id",
                table: "user_crypto",
                column: "crypto_id",
                principalTable: "cryptos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
