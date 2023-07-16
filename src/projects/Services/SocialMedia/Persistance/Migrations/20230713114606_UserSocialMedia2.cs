using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class UserSocialMedia2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserSocialMedias_SocialMediaId",
                table: "UserSocialMedias",
                column: "SocialMediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSocialMedias_SocialMedias_SocialMediaId",
                table: "UserSocialMedias",
                column: "SocialMediaId",
                principalTable: "SocialMedias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSocialMedias_SocialMedias_SocialMediaId",
                table: "UserSocialMedias");

            migrationBuilder.DropIndex(
                name: "IX_UserSocialMedias_SocialMediaId",
                table: "UserSocialMedias");
        }
    }
}
