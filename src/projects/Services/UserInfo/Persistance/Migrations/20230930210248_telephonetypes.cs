using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class telephonetypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTelephoneTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelephoneType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTelephoneTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTelephoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserTelephoneTypeId = table.Column<int>(type: "int", nullable: false),
                    TelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTelephoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTelephoneNumbers_UserTelephoneTypes_UserTelephoneTypeId",
                        column: x => x.UserTelephoneTypeId,
                        principalTable: "UserTelephoneTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserTelephoneTypes",
                columns: new[] { "Id", "TelephoneType" },
                values: new object[] { 1, "Kişisel Telefonu" });

            migrationBuilder.InsertData(
                table: "UserTelephoneTypes",
                columns: new[] { "Id", "TelephoneType" },
                values: new object[] { 2, "İş Telefonu" });

            migrationBuilder.InsertData(
                table: "UserTelephoneTypes",
                columns: new[] { "Id", "TelephoneType" },
                values: new object[] { 3, "Okul Telefonu" });

            migrationBuilder.CreateIndex(
                name: "IX_UserTelephoneNumbers_UserTelephoneTypeId",
                table: "UserTelephoneNumbers",
                column: "UserTelephoneTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTelephoneNumbers");

            migrationBuilder.DropTable(
                name: "UserTelephoneTypes");
        }
    }
}
