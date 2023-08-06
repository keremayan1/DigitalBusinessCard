using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBANAccount.API.Migrations
{
    public partial class UserIbans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Iban",
                table: "Iban");

            migrationBuilder.RenameTable(
                name: "Iban",
                newName: "Ibans");

            migrationBuilder.AddColumn<string>(
                name: "IbanUserName",
                table: "UserIbans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserIbans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ibans",
                table: "Ibans",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserIbans_IbanId",
                table: "UserIbans",
                column: "IbanId");

            migrationBuilder.CreateIndex(
                name: "IX_IbanImages_IbanId",
                table: "IbanImages",
                column: "IbanId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IbanImages_Ibans_IbanId",
                table: "IbanImages",
                column: "IbanId",
                principalTable: "Ibans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserIbans_Ibans_IbanId",
                table: "UserIbans",
                column: "IbanId",
                principalTable: "Ibans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IbanImages_Ibans_IbanId",
                table: "IbanImages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserIbans_Ibans_IbanId",
                table: "UserIbans");

            migrationBuilder.DropIndex(
                name: "IX_UserIbans_IbanId",
                table: "UserIbans");

            migrationBuilder.DropIndex(
                name: "IX_IbanImages_IbanId",
                table: "IbanImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ibans",
                table: "Ibans");

            migrationBuilder.DropColumn(
                name: "IbanUserName",
                table: "UserIbans");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserIbans");

            migrationBuilder.RenameTable(
                name: "Ibans",
                newName: "Iban");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Iban",
                table: "Iban",
                column: "Id");
        }
    }
}
