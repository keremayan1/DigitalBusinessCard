using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class ini2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankIbanAccountImages");

            migrationBuilder.DropTable(
                name: "CompanyBankIbanAccounts");

            migrationBuilder.DropTable(
                name: "BankIbanAccounts");

            migrationBuilder.CreateTable(
                name: "IbanInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IbanInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IbanAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IbanInfoId = table.Column<int>(type: "int", nullable: false),
                    IbanUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IbanNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IbanAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IbanAccounts_IbanInfos_IbanInfoId",
                        column: x => x.IbanInfoId,
                        principalTable: "IbanInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IbanInfoImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IbanInfoId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IbanInfoImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IbanInfoImages_IbanInfos_IbanInfoId",
                        column: x => x.IbanInfoId,
                        principalTable: "IbanInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IbanAccounts_IbanInfoId",
                table: "IbanAccounts",
                column: "IbanInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_IbanInfoImages_IbanInfoId",
                table: "IbanInfoImages",
                column: "IbanInfoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IbanAccounts");

            migrationBuilder.DropTable(
                name: "IbanInfoImages");

            migrationBuilder.DropTable(
                name: "IbanInfos");

            migrationBuilder.CreateTable(
                name: "BankIbanAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankIbanAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankIbanAccountImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankIbanAccountId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankIbanAccountImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankIbanAccountImages_BankIbanAccounts_BankIbanAccountId",
                        column: x => x.BankIbanAccountId,
                        principalTable: "BankIbanAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyBankIbanAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankIbanAccountId = table.Column<int>(type: "int", nullable: false),
                    IbanNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IbanUserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "IX_BankIbanAccountImages_BankIbanAccountId",
                table: "BankIbanAccountImages",
                column: "BankIbanAccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBankIbanAccounts_BankIbanAccountId",
                table: "CompanyBankIbanAccounts",
                column: "BankIbanAccountId");
        }
    }
}
