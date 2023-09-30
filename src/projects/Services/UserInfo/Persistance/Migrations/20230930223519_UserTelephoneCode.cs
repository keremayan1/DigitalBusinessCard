using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class UserTelephoneCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserTelephoneCountryId",
                table: "UserTelephoneNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserTelephoneCountries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryDialCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTelephoneCountries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UserTelephoneCountries",
                columns: new[] { "Id", "CountryCode", "CountryDialCode", "CountryName" },
                values: new object[,]
                {
                    { 1, "AF", "+93", "Afghanistan" },
                    { 2, "AL", "+355", "Albania" },
                    { 3, "DZ", "+213", "Algeria" },
                    { 4, "AD", "+376", "Andorra" },
                    { 5, "AO", "+244", "Angola" },
                    { 6, "AG", "+1", "Antigua and Barbuda" },
                    { 7, "AR", "+54", "Argentina" },
                    { 8, "AM", "+374", "Armenia" },
                    { 9, "AU", "+61", "Australia" },
                    { 10, "AT", "+43", "Austria" },
                    { 11, "AZ", "+994", "Azerbaijan" },
                    { 12, "BS", "+1", "Bahamas" },
                    { 13, "BH", "+973", "Bahrain" },
                    { 14, "BD", "+880", "Bangladesh" },
                    { 15, "BB", "+1", "Barbados" },
                    { 16, "BY", "+375", "Belarus" },
                    { 17, "BE", "+32", "Belgium" },
                    { 18, "BZ", "+501", "Belize" },
                    { 19, "BJ", "+229", "Benin" },
                    { 20, "BT", "+975", "Bhutan" },
                    { 21, "BO", "+591", "Bolivia" },
                    { 22, "BA", "+387", "Bosnia and Herzegovina" },
                    { 23, "BW", "+267", "Botswana" },
                    { 24, "BR", "+55", "Brazil" },
                    { 25, "BN", "+673", "Brunei" },
                    { 26, "BG", "+359", "Bulgaria" },
                    { 27, "BF", "+226", "Burkina Faso" },
                    { 28, "BI", "+257", "Burundi" },
                    { 29, "CV", "+238", "Cabo Verde" },
                    { 30, "KH", "+855", "Cambodia" },
                    { 31, "CM", "+237", "Cameroon" },
                    { 32, "CA", "+1", "Canada" },
                    { 33, "CF", "+236", "Central African Republic" },
                    { 34, "TD", "+235", "Chad" },
                    { 35, "CL", "+56", "Chile" },
                    { 36, "CN", "+86", "China" },
                    { 37, "CO", "+57", "Colombia" },
                    { 38, "KM", "+269", "Comoros" },
                    { 39, "CG", "+242", "Congo" },
                    { 40, "CR", "+506", "Costa Rica" },
                    { 41, "HR", "+385", "Croatia" },
                    { 42, "CU", "+53", "Cuba" }
                });

            migrationBuilder.InsertData(
                table: "UserTelephoneCountries",
                columns: new[] { "Id", "CountryCode", "CountryDialCode", "CountryName" },
                values: new object[,]
                {
                    { 43, "CY", "+357", "Cyprus" },
                    { 44, "CZ", "+420", "Czech Republic" },
                    { 45, "DK", "+45", "Denmark" },
                    { 46, "DJ", "+253", "Djibouti" },
                    { 47, "DM", "+1", "Dominica" },
                    { 48, "DO", "+1", "Dominican Republic" },
                    { 49, "EC", "+593", "Ecuador" },
                    { 50, "EG", "+20", "Egypt" },
                    { 51, "SV", "+503", "El Salvador" },
                    { 52, "GQ", "+240", "Equatorial Guinea" },
                    { 53, "ER", "+291", "Eritrea" },
                    { 54, "EE", "+372", "Estonia" },
                    { 55, "SZ", "+268", "Eswatini" },
                    { 56, "ET", "+251", "Ethiopia" },
                    { 57, "FJ", "+679", "Fiji" },
                    { 58, "FI", "+358", "Finland" },
                    { 59, "FR", "+33", "France" },
                    { 60, "GA", "+241", "Gabon" },
                    { 61, "GM", "+220", "Gambia" },
                    { 62, "GE", "+995", "Georgia" },
                    { 63, "DE", "+49", "Germany" },
                    { 64, "GH", "+233", "Ghana" },
                    { 65, "GR", "+30", "Greece" },
                    { 66, "GD", "+1", "Grenada" },
                    { 67, "GT", "+502", "Guatemala" },
                    { 68, "GN", "+224", "Guinea" },
                    { 69, "GW", "+245", "Guinea-Bissau" },
                    { 70, "GY", "+592", "Guyana" },
                    { 71, "HT", "+509", "Haiti" },
                    { 72, "HN", "+504", "Honduras" },
                    { 73, "HU", "+36", "Hungary" },
                    { 74, "IS", "+354", "Iceland" },
                    { 75, "IN", "+91", "India" },
                    { 76, "ID", "+62", "Indonesia" },
                    { 77, "IR", "+98", "Iran" },
                    { 78, "IQ", "+964", "Iraq" },
                    { 79, "IE", "+353", "Ireland" },
                    { 80, "IL", "+972", "Israel" },
                    { 81, "IT", "+39", "Italy" },
                    { 82, "JM", "+1", "Jamaica" },
                    { 83, "JP", "+81", "Japan" },
                    { 84, "JO", "+962", "Jordan" }
                });

            migrationBuilder.InsertData(
                table: "UserTelephoneCountries",
                columns: new[] { "Id", "CountryCode", "CountryDialCode", "CountryName" },
                values: new object[,]
                {
                    { 85, "KZ", "+7", "Kazakhstan" },
                    { 86, "KE", "+254", "Kenya" },
                    { 87, "KI", "+686", "Kiribati" },
                    { 88, "KP", "+850", "Korea, North" },
                    { 89, "KR", "+82", "Korea, South" },
                    { 90, "KW", "+965", "Kuwait" },
                    { 91, "KG", "+996", "Kyrgyzstan" },
                    { 92, "LA", "+856", "Laos" },
                    { 93, "LV", "+371", "Latvia" },
                    { 94, "LB", "+961", "Lebanon" },
                    { 95, "LS", "+266", "Lesotho" },
                    { 96, "LR", "+231", "Liberia" },
                    { 97, "LY", "+218", "Libya" },
                    { 98, "LI", "+423", "Liechtenstein" },
                    { 99, "LT", "+370", "Lithuania" },
                    { 100, "LU", "+352", "Luxembourg" },
                    { 101, "MG", "+261", "Madagascar" },
                    { 102, "MW", "+265", "Malawi" },
                    { 103, "MY", "+60", "Malaysia" },
                    { 104, "MV", "+960", "Maldives" },
                    { 105, "ML", "+223", "Mali" },
                    { 106, "MT", "+356", "Malta" },
                    { 107, "MH", "+692", "Marshall Islands" },
                    { 108, "MR", "+222", "Mauritania" },
                    { 109, "MU", "+230", "Mauritius" },
                    { 110, "MX", "+52", "Mexico" },
                    { 111, "FM", "+691", "Micronesia" },
                    { 112, "MD", "+373", "Moldova" },
                    { 113, "MC", "+377", "Monaco" },
                    { 114, "MN", "+976", "Mongolia" },
                    { 115, "ME", "+382", "Montenegro" },
                    { 116, "MA", "+212", "Morocco" },
                    { 117, "MZ", "+258", "Mozambique" },
                    { 118, "MM", "+95", "Myanmar" },
                    { 119, "NA", "+264", "Namibia" },
                    { 120, "NR", "+674", "Nauru" },
                    { 121, "NP", "+977", "Nepal" },
                    { 122, "NL", "+31", "Netherlands" },
                    { 123, "NZ", "+64", "New Zealand" },
                    { 124, "NI", "+505", "Nicaragua" },
                    { 125, "NE", "+227", "Niger" },
                    { 126, "NG", "+234", "Nigeria" }
                });

            migrationBuilder.InsertData(
                table: "UserTelephoneCountries",
                columns: new[] { "Id", "CountryCode", "CountryDialCode", "CountryName" },
                values: new object[,]
                {
                    { 127, "MK", "+389", "North Macedonia" },
                    { 128, "NO", "+47", "Norway" },
                    { 129, "OM", "+968", "Oman" },
                    { 130, "PK", "+92", "Pakistan" },
                    { 131, "PW", "+680", "Palau" },
                    { 132, "PS", "+970", "Palestine" },
                    { 133, "PA", "+507", "Panama" },
                    { 134, "PG", "+675", "Papua New Guinea" },
                    { 135, "PY", "+595", "Paraguay" },
                    { 136, "PE", "+51", "Peru" },
                    { 137, "PH", "+63", "Philippines" },
                    { 138, "PL", "+48", "Poland" },
                    { 139, "PT", "+351", "Portugal" },
                    { 140, "QA", "+974", "Qatar" },
                    { 141, "RO", "+40", "Romania" },
                    { 142, "RU", "+7", "Russia" },
                    { 143, "RW", "+250", "Rwanda" },
                    { 144, "KN", "+1", "Saint Kitts and Nevis" },
                    { 145, "LC", "+1", "Saint Lucia" },
                    { 146, "VC", "+1", "Saint Vincent and the Grenadines" },
                    { 147, "WS", "+685", "Samoa" },
                    { 148, "SM", "+378", "San Marino" },
                    { 149, "ST", "+239", "Sao Tome and Principe" },
                    { 150, "SA", "+966", "Saudi Arabia" },
                    { 151, "SN", "+221", "Senegal" },
                    { 152, "RS", "+381", "Serbia" },
                    { 153, "SC", "+248", "Seychelles" },
                    { 154, "SL", "+232", "Sierra Leone" },
                    { 155, "SG", "+65", "Singapore" },
                    { 156, "SK", "+421", "Slovakia" },
                    { 157, "SI", "+386", "Slovenia" },
                    { 158, "SB", "+677", "Solomon Islands" },
                    { 159, "SO", "+252", "Somalia" },
                    { 160, "ZA", "+27", "South Africa" },
                    { 161, "SS", "+211", "South Sudan" },
                    { 162, "ES", "+34", "Spain" },
                    { 163, "LK", "+94", "Sri Lanka" },
                    { 164, "SD", "+249", "Sudan" },
                    { 165, "SR", "+597", "SuriCountryName" },
                    { 166, "SE", "+46", "Sweden" },
                    { 167, "CH", "+41", "Switzerland" },
                    { 168, "SY", "+963", "Syria" }
                });

            migrationBuilder.InsertData(
                table: "UserTelephoneCountries",
                columns: new[] { "Id", "CountryCode", "CountryDialCode", "CountryName" },
                values: new object[,]
                {
                    { 169, "TW", "+886", "Taiwan" },
                    { 170, "TJ", "+992", "Tajikistan" },
                    { 171, "TZ", "+255", "Tanzania" },
                    { 172, "TH", "+66", "Thailand" },
                    { 173, "TL", "+670", "Timor-Leste" },
                    { 174, "TG", "+228", "Togo" },
                    { 175, "TO", "+676", "Tonga" },
                    { 176, "TT", "+1", "Trinidad and Tobago" },
                    { 177, "TN", "+216", "Tunisia" },
                    { 178, "TR", "+90", "Turkey" },
                    { 179, "TM", "+993", "Turkmenistan" },
                    { 180, "TV", "+688", "Tuvalu" },
                    { 181, "UG", "+256", "Uganda" },
                    { 182, "UA", "+380", "Ukraine" },
                    { 183, "AE", "+971", "United Arab Emirates" },
                    { 184, "GB", "+44", "United Kingdom" },
                    { 185, "US", "+1", "United States" },
                    { 186, "UY", "+598", "Uruguay" },
                    { 187, "UZ", "+998", "Uzbekistan" },
                    { 188, "VU", "+678", "Vanuatu" },
                    { 189, "VA", "+39", "Vatican City" },
                    { 190, "VE", "+58", "Venezuela" },
                    { 191, "VN", "+84", "Vietnam" },
                    { 192, "YE", "+967", "Yemen" },
                    { 193, "ZM", "+260", "Zambia" },
                    { 194, "ZW", "+263", "Zimbabwe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTelephoneNumbers_UserTelephoneCountryId",
                table: "UserTelephoneNumbers",
                column: "UserTelephoneCountryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTelephoneNumbers_UserTelephoneCountries_UserTelephoneCountryId",
                table: "UserTelephoneNumbers",
                column: "UserTelephoneCountryId",
                principalTable: "UserTelephoneCountries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTelephoneNumbers_UserTelephoneCountries_UserTelephoneCountryId",
                table: "UserTelephoneNumbers");

            migrationBuilder.DropTable(
                name: "UserTelephoneCountries");

            migrationBuilder.DropIndex(
                name: "IX_UserTelephoneNumbers_UserTelephoneCountryId",
                table: "UserTelephoneNumbers");

            migrationBuilder.DropColumn(
                name: "UserTelephoneCountryId",
                table: "UserTelephoneNumbers");
        }
    }
}
