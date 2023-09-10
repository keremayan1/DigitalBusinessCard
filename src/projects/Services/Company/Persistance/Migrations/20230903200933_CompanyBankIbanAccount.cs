using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class CompanyBankIbanAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyBankIbanAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankIbanAccountId = table.Column<int>(type: "int", nullable: false),
                    IbanUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IbanNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyBankIbanAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyBankIbanAccounts_BankIbanAccounts_BankIbanAccountId",
                        column: x => x.BankIbanAccountId,
                        principalTable: "BankIbanAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBankIbanAccounts_BankIbanAccountId",
                table: "CompanyBankIbanAccounts",
                column: "BankIbanAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyBankIbanAccounts");
        }
    }
}
