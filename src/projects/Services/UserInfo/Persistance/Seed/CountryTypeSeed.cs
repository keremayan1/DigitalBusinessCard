﻿using Domain.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Seed
{
    public class UserTelephoneCountryTypeSeed : IEntityTypeConfiguration<UserTelephoneCountry>
    {
        public void Configure(EntityTypeBuilder<UserTelephoneCountry> builder)
        {
            builder.HasData(
                new UserTelephoneCountry { Id = 1, CountryName = "Afghanistan", CountryDialCode = "+93", CountryCode = "AF" },
                new UserTelephoneCountry { Id = 2, CountryName = "Albania", CountryDialCode = "+355", CountryCode = "AL" },
                new UserTelephoneCountry { Id = 3, CountryName = "Algeria", CountryDialCode = "+213", CountryCode = "DZ" },
                new UserTelephoneCountry { Id = 4, CountryName = "Andorra", CountryDialCode = "+376", CountryCode = "AD" },
                new UserTelephoneCountry { Id = 5, CountryName = "Angola", CountryDialCode = "+244", CountryCode = "AO" },
                new UserTelephoneCountry { Id = 6, CountryName = "Antigua and Barbuda", CountryDialCode = "+1", CountryCode = "AG" },
                new UserTelephoneCountry { Id = 7, CountryName = "Argentina", CountryDialCode = "+54", CountryCode = "AR" },
                new UserTelephoneCountry { Id = 8, CountryName = "Armenia", CountryDialCode = "+374", CountryCode = "AM" },
                new UserTelephoneCountry { Id = 9, CountryName = "Australia", CountryDialCode = "+61", CountryCode = "AU" },
                new UserTelephoneCountry { Id = 10, CountryName = "Austria", CountryDialCode = "+43", CountryCode = "AT" },
                new UserTelephoneCountry { Id = 11, CountryName = "Azerbaijan", CountryDialCode = "+994", CountryCode = "AZ" },
                new UserTelephoneCountry { Id = 12, CountryName = "Bahamas", CountryDialCode = "+1", CountryCode = "BS" },
                new UserTelephoneCountry { Id = 13, CountryName = "Bahrain", CountryDialCode = "+973", CountryCode = "BH" },
                new UserTelephoneCountry { Id = 14, CountryName = "Bangladesh", CountryDialCode = "+880", CountryCode = "BD" },
                new UserTelephoneCountry { Id = 15, CountryName = "Barbados", CountryDialCode = "+1", CountryCode = "BB" },
                new UserTelephoneCountry { Id = 16, CountryName = "Belarus", CountryDialCode = "+375", CountryCode = "BY" },
                new UserTelephoneCountry { Id = 17, CountryName = "Belgium", CountryDialCode = "+32", CountryCode = "BE" },
                new UserTelephoneCountry { Id = 18, CountryName = "Belize", CountryDialCode = "+501", CountryCode = "BZ" },
                new UserTelephoneCountry { Id = 19, CountryName = "Benin", CountryDialCode = "+229", CountryCode = "BJ" },
                new UserTelephoneCountry { Id = 20, CountryName = "Bhutan", CountryDialCode = "+975", CountryCode = "BT" },
                new UserTelephoneCountry { Id = 21, CountryName = "Bolivia", CountryDialCode = "+591", CountryCode = "BO" },
                new UserTelephoneCountry { Id = 22, CountryName = "Bosnia and Herzegovina", CountryDialCode = "+387", CountryCode = "BA" },
                new UserTelephoneCountry { Id = 23, CountryName = "Botswana", CountryDialCode = "+267", CountryCode = "BW" },
                new UserTelephoneCountry { Id = 24, CountryName = "Brazil", CountryDialCode = "+55", CountryCode = "BR" },
                new UserTelephoneCountry { Id = 25, CountryName = "Brunei", CountryDialCode = "+673", CountryCode = "BN" },
                new UserTelephoneCountry { Id = 26, CountryName = "Bulgaria", CountryDialCode = "+359", CountryCode = "BG" },
                new UserTelephoneCountry { Id = 27, CountryName = "Burkina Faso", CountryDialCode = "+226", CountryCode = "BF" },
                new UserTelephoneCountry { Id = 28, CountryName = "Burundi", CountryDialCode = "+257", CountryCode = "BI" },
                new UserTelephoneCountry { Id = 29, CountryName = "Cabo Verde", CountryDialCode = "+238", CountryCode = "CV" },
                new UserTelephoneCountry { Id = 30, CountryName = "Cambodia", CountryDialCode = "+855", CountryCode = "KH" },
                new UserTelephoneCountry { Id = 31, CountryName = "Cameroon", CountryDialCode = "+237", CountryCode = "CM" },
                new UserTelephoneCountry { Id = 32, CountryName = "Canada", CountryDialCode = "+1", CountryCode = "CA" },
                new UserTelephoneCountry { Id = 33, CountryName = "Central African Republic", CountryDialCode = "+236", CountryCode = "CF" },
                new UserTelephoneCountry { Id = 34, CountryName = "Chad", CountryDialCode = "+235", CountryCode = "TD" },
                new UserTelephoneCountry { Id = 35, CountryName = "Chile", CountryDialCode = "+56", CountryCode = "CL" },
                new UserTelephoneCountry { Id = 36, CountryName = "China", CountryDialCode = "+86", CountryCode = "CN" },
                new UserTelephoneCountry { Id = 37, CountryName = "Colombia", CountryDialCode = "+57", CountryCode = "CO" },
                new UserTelephoneCountry { Id = 38, CountryName = "Comoros", CountryDialCode = "+269", CountryCode = "KM" },
                new UserTelephoneCountry { Id = 39, CountryName = "Congo", CountryDialCode = "+242", CountryCode = "CG" },
                new UserTelephoneCountry { Id = 40, CountryName = "Costa Rica", CountryDialCode = "+506", CountryCode = "CR" },
                new UserTelephoneCountry { Id = 41, CountryName = "Croatia", CountryDialCode = "+385", CountryCode = "HR" },
                new UserTelephoneCountry { Id = 42, CountryName = "Cuba", CountryDialCode = "+53", CountryCode = "CU" },
                new UserTelephoneCountry { Id = 43, CountryName = "Cyprus", CountryDialCode = "+357", CountryCode = "CY" },
                new UserTelephoneCountry { Id = 44, CountryName = "Czech Republic", CountryDialCode = "+420", CountryCode = "CZ" },
                new UserTelephoneCountry { Id = 45, CountryName = "Denmark", CountryDialCode = "+45", CountryCode = "DK" },
                new UserTelephoneCountry { Id = 46, CountryName = "Djibouti", CountryDialCode = "+253", CountryCode = "DJ" },
                new UserTelephoneCountry { Id = 47, CountryName = "Dominica", CountryDialCode = "+1", CountryCode = "DM" },
                new UserTelephoneCountry { Id = 48, CountryName = "Dominican Republic", CountryDialCode = "+1", CountryCode = "DO" },
                new UserTelephoneCountry { Id = 49, CountryName = "Ecuador", CountryDialCode = "+593", CountryCode = "EC" },
                new UserTelephoneCountry { Id = 50, CountryName = "Egypt", CountryDialCode = "+20", CountryCode = "EG" },
                new UserTelephoneCountry { Id = 51, CountryName = "El Salvador", CountryDialCode = "+503", CountryCode = "SV" },
                new UserTelephoneCountry { Id = 52, CountryName = "Equatorial Guinea", CountryDialCode = "+240", CountryCode = "GQ" },
                new UserTelephoneCountry { Id = 53, CountryName = "Eritrea", CountryDialCode = "+291", CountryCode = "ER" },
                new UserTelephoneCountry { Id = 54, CountryName = "Estonia", CountryDialCode = "+372", CountryCode = "EE" },
                new UserTelephoneCountry { Id = 55, CountryName = "Eswatini", CountryDialCode = "+268", CountryCode = "SZ" },
                new UserTelephoneCountry { Id = 56, CountryName = "Ethiopia", CountryDialCode = "+251", CountryCode = "ET" },
                new UserTelephoneCountry { Id = 57, CountryName = "Fiji", CountryDialCode = "+679", CountryCode = "FJ" },
                new UserTelephoneCountry { Id = 58, CountryName = "Finland", CountryDialCode = "+358", CountryCode = "FI" },
                new UserTelephoneCountry { Id = 59, CountryName = "France", CountryDialCode = "+33", CountryCode = "FR" },
                new UserTelephoneCountry { Id = 60, CountryName = "Gabon", CountryDialCode = "+241", CountryCode = "GA" },
                new UserTelephoneCountry { Id = 61, CountryName = "Gambia", CountryDialCode = "+220", CountryCode = "GM" },
                new UserTelephoneCountry { Id = 62, CountryName = "Georgia", CountryDialCode = "+995", CountryCode = "GE" },
                new UserTelephoneCountry { Id = 63, CountryName = "Germany", CountryDialCode = "+49", CountryCode = "DE" },
                new UserTelephoneCountry { Id = 64, CountryName = "Ghana", CountryDialCode = "+233", CountryCode = "GH" },
                new UserTelephoneCountry { Id = 65, CountryName = "Greece", CountryDialCode = "+30", CountryCode = "GR" },
                new UserTelephoneCountry { Id = 66, CountryName = "Grenada", CountryDialCode = "+1", CountryCode = "GD" },
                new UserTelephoneCountry { Id = 67, CountryName = "Guatemala", CountryDialCode = "+502", CountryCode = "GT" },
                new UserTelephoneCountry { Id = 68, CountryName = "Guinea", CountryDialCode = "+224", CountryCode = "GN" },
                new UserTelephoneCountry { Id = 69, CountryName = "Guinea-Bissau", CountryDialCode = "+245", CountryCode = "GW" },
                new UserTelephoneCountry { Id = 70, CountryName = "Guyana", CountryDialCode = "+592", CountryCode = "GY" },
                new UserTelephoneCountry { Id = 71, CountryName = "Haiti", CountryDialCode = "+509", CountryCode = "HT" },
                new UserTelephoneCountry { Id = 72, CountryName = "Honduras", CountryDialCode = "+504", CountryCode = "HN" },
                new UserTelephoneCountry { Id = 73, CountryName = "Hungary", CountryDialCode = "+36", CountryCode = "HU" },
                new UserTelephoneCountry { Id = 74, CountryName = "Iceland", CountryDialCode = "+354", CountryCode = "IS" },
                new UserTelephoneCountry { Id = 75, CountryName = "India", CountryDialCode = "+91", CountryCode = "IN" },
                new UserTelephoneCountry { Id = 76, CountryName = "Indonesia", CountryDialCode = "+62", CountryCode = "ID" },
                new UserTelephoneCountry { Id = 77, CountryName = "Iran", CountryDialCode = "+98", CountryCode = "IR" },
                new UserTelephoneCountry { Id = 78, CountryName = "Iraq", CountryDialCode = "+964", CountryCode = "IQ" },
                new UserTelephoneCountry { Id = 79, CountryName = "Ireland", CountryDialCode = "+353", CountryCode = "IE" },
                new UserTelephoneCountry { Id = 80, CountryName = "Israel", CountryDialCode = "+972", CountryCode = "IL" },
                new UserTelephoneCountry { Id = 81, CountryName = "Italy", CountryDialCode = "+39", CountryCode = "IT" },
                new UserTelephoneCountry { Id = 82, CountryName = "Jamaica", CountryDialCode = "+1", CountryCode = "JM" },
                new UserTelephoneCountry { Id = 83, CountryName = "Japan", CountryDialCode = "+81", CountryCode = "JP" },
                new UserTelephoneCountry { Id = 84, CountryName = "Jordan", CountryDialCode = "+962", CountryCode = "JO" },
                new UserTelephoneCountry { Id = 85, CountryName = "Kazakhstan", CountryDialCode = "+7", CountryCode = "KZ" },
                new UserTelephoneCountry { Id = 86, CountryName = "Kenya", CountryDialCode = "+254", CountryCode = "KE" },
                new UserTelephoneCountry { Id = 87, CountryName = "Kiribati", CountryDialCode = "+686", CountryCode = "KI" },
                new UserTelephoneCountry { Id = 88, CountryName = "Korea, North", CountryDialCode = "+850", CountryCode = "KP" },
                new UserTelephoneCountry { Id = 89, CountryName = "Korea, South", CountryDialCode = "+82", CountryCode = "KR" },
                new UserTelephoneCountry { Id = 90, CountryName = "Kuwait", CountryDialCode = "+965", CountryCode = "KW" },
                new UserTelephoneCountry { Id = 91, CountryName = "Kyrgyzstan", CountryDialCode = "+996", CountryCode = "KG" },
                new UserTelephoneCountry { Id = 92, CountryName = "Laos", CountryDialCode = "+856", CountryCode = "LA" },
                new UserTelephoneCountry { Id = 93, CountryName = "Latvia", CountryDialCode = "+371", CountryCode = "LV" },
                new UserTelephoneCountry { Id = 94, CountryName = "Lebanon", CountryDialCode = "+961", CountryCode = "LB" },
                new UserTelephoneCountry { Id = 95, CountryName = "Lesotho", CountryDialCode = "+266", CountryCode = "LS" },
                new UserTelephoneCountry { Id = 96, CountryName = "Liberia", CountryDialCode = "+231", CountryCode = "LR" },
                new UserTelephoneCountry { Id = 97, CountryName = "Libya", CountryDialCode = "+218", CountryCode = "LY" },
                new UserTelephoneCountry { Id = 98, CountryName = "Liechtenstein", CountryDialCode = "+423", CountryCode = "LI" },
                new UserTelephoneCountry { Id = 99, CountryName = "Lithuania", CountryDialCode = "+370", CountryCode = "LT" },
                new UserTelephoneCountry { Id = 100, CountryName = "Luxembourg", CountryDialCode = "+352", CountryCode = "LU" },
                new UserTelephoneCountry { Id = 101, CountryName = "Madagascar", CountryDialCode = "+261", CountryCode = "MG" },
                new UserTelephoneCountry { Id = 102, CountryName = "Malawi", CountryDialCode = "+265", CountryCode = "MW" },
                new UserTelephoneCountry { Id = 103, CountryName = "Malaysia", CountryDialCode = "+60", CountryCode = "MY" },
                new UserTelephoneCountry { Id = 104, CountryName = "Maldives", CountryDialCode = "+960", CountryCode = "MV" },
                new UserTelephoneCountry { Id = 105, CountryName = "Mali", CountryDialCode = "+223", CountryCode = "ML" },
                new UserTelephoneCountry { Id = 106, CountryName = "Malta", CountryDialCode = "+356", CountryCode = "MT" },
                new UserTelephoneCountry { Id = 107, CountryName = "Marshall Islands", CountryDialCode = "+692", CountryCode = "MH" },
                new UserTelephoneCountry { Id = 108, CountryName = "Mauritania", CountryDialCode = "+222", CountryCode = "MR" },
                new UserTelephoneCountry { Id = 109, CountryName = "Mauritius", CountryDialCode = "+230", CountryCode = "MU" },
                new UserTelephoneCountry { Id = 110, CountryName = "Mexico", CountryDialCode = "+52", CountryCode = "MX" },
                new UserTelephoneCountry { Id = 111, CountryName = "Micronesia", CountryDialCode = "+691", CountryCode = "FM" },
                new UserTelephoneCountry { Id = 112, CountryName = "Moldova", CountryDialCode = "+373", CountryCode = "MD" },
                new UserTelephoneCountry { Id = 113, CountryName = "Monaco", CountryDialCode = "+377", CountryCode = "MC" },
                new UserTelephoneCountry { Id = 114, CountryName = "Mongolia", CountryDialCode = "+976", CountryCode = "MN" },
                new UserTelephoneCountry { Id = 115, CountryName = "Montenegro", CountryDialCode = "+382", CountryCode = "ME" },
                new UserTelephoneCountry { Id = 116, CountryName = "Morocco", CountryDialCode = "+212", CountryCode = "MA" },
                new UserTelephoneCountry { Id = 117, CountryName = "Mozambique", CountryDialCode = "+258", CountryCode = "MZ" },
                new UserTelephoneCountry { Id = 118, CountryName = "Myanmar", CountryDialCode = "+95", CountryCode = "MM" },
                new UserTelephoneCountry { Id = 119, CountryName = "Namibia", CountryDialCode = "+264", CountryCode = "NA" },
                new UserTelephoneCountry { Id = 120, CountryName = "Nauru", CountryDialCode = "+674", CountryCode = "NR" },
                new UserTelephoneCountry { Id = 121, CountryName = "Nepal", CountryDialCode = "+977", CountryCode = "NP" },
                new UserTelephoneCountry { Id = 122, CountryName = "Netherlands", CountryDialCode = "+31", CountryCode = "NL" },
                new UserTelephoneCountry { Id = 123, CountryName = "New Zealand", CountryDialCode = "+64", CountryCode = "NZ" },
                new UserTelephoneCountry { Id = 124, CountryName = "Nicaragua", CountryDialCode = "+505", CountryCode = "NI" },
                new UserTelephoneCountry { Id = 125, CountryName = "Niger", CountryDialCode = "+227", CountryCode = "NE" },
                new UserTelephoneCountry { Id = 126, CountryName = "Nigeria", CountryDialCode = "+234", CountryCode = "NG" },
                new UserTelephoneCountry { Id = 127, CountryName = "North Macedonia", CountryDialCode = "+389", CountryCode = "MK" },
                new UserTelephoneCountry { Id = 128, CountryName = "Norway", CountryDialCode = "+47", CountryCode = "NO" },
                new UserTelephoneCountry { Id = 129, CountryName = "Oman", CountryDialCode = "+968", CountryCode = "OM" },
                new UserTelephoneCountry { Id = 130, CountryName = "Pakistan", CountryDialCode = "+92", CountryCode = "PK" },
                new UserTelephoneCountry { Id = 131, CountryName = "Palau", CountryDialCode = "+680", CountryCode = "PW" },
                new UserTelephoneCountry { Id = 132, CountryName = "Palestine", CountryDialCode = "+970", CountryCode = "PS" },
                new UserTelephoneCountry { Id = 133, CountryName = "Panama", CountryDialCode = "+507", CountryCode = "PA" },
                new UserTelephoneCountry { Id = 134, CountryName = "Papua New Guinea", CountryDialCode = "+675", CountryCode = "PG" },
                new UserTelephoneCountry { Id = 135, CountryName = "Paraguay", CountryDialCode = "+595", CountryCode = "PY" },
                new UserTelephoneCountry { Id = 136, CountryName = "Peru", CountryDialCode = "+51", CountryCode = "PE" },
                new UserTelephoneCountry { Id = 137, CountryName = "Philippines", CountryDialCode = "+63", CountryCode = "PH" },
                new UserTelephoneCountry { Id = 138, CountryName = "Poland", CountryDialCode = "+48", CountryCode = "PL" },
                new UserTelephoneCountry { Id = 139, CountryName = "Portugal", CountryDialCode = "+351", CountryCode = "PT" },
                new UserTelephoneCountry { Id = 140, CountryName = "Qatar", CountryDialCode = "+974", CountryCode = "QA" },
                new UserTelephoneCountry { Id = 141, CountryName = "Romania", CountryDialCode = "+40", CountryCode = "RO" },
                new UserTelephoneCountry { Id = 142, CountryName = "Russia", CountryDialCode = "+7", CountryCode = "RU" },
                new UserTelephoneCountry { Id = 143, CountryName = "Rwanda", CountryDialCode = "+250", CountryCode = "RW" },
                new UserTelephoneCountry { Id = 144, CountryName = "Saint Kitts and Nevis", CountryDialCode = "+1", CountryCode = "KN" },
                new UserTelephoneCountry { Id = 145, CountryName = "Saint Lucia", CountryDialCode = "+1", CountryCode = "LC" },
                new UserTelephoneCountry { Id=146,CountryName = "Saint Vincent and the Grenadines", CountryDialCode = "+1", CountryCode =   "VC" },
                new UserTelephoneCountry { Id = 147, CountryName = "Samoa", CountryDialCode = "+685", CountryCode = "WS" },
                new UserTelephoneCountry { Id = 148, CountryName = "San Marino", CountryDialCode = "+378", CountryCode = "SM" },
                new UserTelephoneCountry { Id = 149, CountryName = "Sao Tome and Principe", CountryDialCode = "+239", CountryCode = "ST" },
                new UserTelephoneCountry { Id = 150, CountryName = "Saudi Arabia", CountryDialCode = "+966", CountryCode = "SA" },
                new UserTelephoneCountry { Id = 151, CountryName = "Senegal", CountryDialCode = "+221", CountryCode = "SN" },
                new UserTelephoneCountry { Id = 152, CountryName = "Serbia", CountryDialCode = "+381", CountryCode = "RS" },
                new UserTelephoneCountry { Id = 153, CountryName = "Seychelles", CountryDialCode = "+248", CountryCode = "SC" },
                new UserTelephoneCountry { Id = 154, CountryName = "Sierra Leone", CountryDialCode = "+232", CountryCode = "SL" },
                new UserTelephoneCountry { Id = 155, CountryName = "Singapore", CountryDialCode = "+65", CountryCode = "SG" },
                new UserTelephoneCountry { Id = 156, CountryName = "Slovakia", CountryDialCode = "+421", CountryCode = "SK" },
                new UserTelephoneCountry { Id = 157, CountryName = "Slovenia", CountryDialCode = "+386", CountryCode = "SI" },
                new UserTelephoneCountry { Id = 158, CountryName = "Solomon Islands", CountryDialCode = "+677", CountryCode = "SB" },
                new UserTelephoneCountry { Id = 159, CountryName = "Somalia", CountryDialCode = "+252", CountryCode = "SO" },
                new UserTelephoneCountry { Id = 160, CountryName = "South Africa", CountryDialCode = "+27", CountryCode = "ZA" },
                new UserTelephoneCountry { Id = 161, CountryName = "South Sudan", CountryDialCode = "+211", CountryCode = "SS" },
                new UserTelephoneCountry { Id = 162, CountryName = "Spain", CountryDialCode = "+34", CountryCode = "ES" },
                new UserTelephoneCountry { Id = 163, CountryName = "Sri Lanka", CountryDialCode = "+94", CountryCode = "LK" },
                new UserTelephoneCountry { Id = 164, CountryName = "Sudan", CountryDialCode = "+249", CountryCode = "SD" },
                new UserTelephoneCountry { Id = 165, CountryName = "SuriCountryName", CountryDialCode = "+597", CountryCode = "SR" },
                new UserTelephoneCountry { Id = 166, CountryName = "Sweden", CountryDialCode = "+46", CountryCode = "SE" },
                new UserTelephoneCountry { Id = 167, CountryName = "Switzerland", CountryDialCode = "+41", CountryCode = "CH" },
                new UserTelephoneCountry { Id = 168, CountryName = "Syria", CountryDialCode = "+963", CountryCode = "SY" },
                new UserTelephoneCountry { Id = 169, CountryName = "Taiwan", CountryDialCode = "+886", CountryCode = "TW" },
                new UserTelephoneCountry { Id = 170, CountryName = "Tajikistan", CountryDialCode = "+992", CountryCode = "TJ" },
                new UserTelephoneCountry { Id = 171, CountryName = "Tanzania", CountryDialCode = "+255", CountryCode = "TZ" },
                new UserTelephoneCountry { Id = 172, CountryName = "Thailand", CountryDialCode = "+66", CountryCode = "TH" },
                new UserTelephoneCountry { Id = 173, CountryName = "Timor-Leste", CountryDialCode = "+670", CountryCode = "TL" },
                new UserTelephoneCountry { Id = 174, CountryName = "Togo", CountryDialCode = "+228", CountryCode = "TG" },
                new UserTelephoneCountry { Id = 175, CountryName = "Tonga", CountryDialCode = "+676", CountryCode = "TO" },
                new UserTelephoneCountry { Id = 176, CountryName = "Trinidad and Tobago", CountryDialCode = "+1", CountryCode = "TT" },
                new UserTelephoneCountry { Id = 177, CountryName = "Tunisia", CountryDialCode = "+216", CountryCode = "TN" },
                new UserTelephoneCountry { Id = 178, CountryName = "Turkey", CountryDialCode = "+90", CountryCode = "TR" },
                new UserTelephoneCountry { Id = 179, CountryName = "Turkmenistan", CountryDialCode = "+993", CountryCode = "TM" },
                new UserTelephoneCountry { Id = 180, CountryName = "Tuvalu", CountryDialCode = "+688", CountryCode = "TV" },
                new UserTelephoneCountry { Id = 181, CountryName = "Uganda", CountryDialCode = "+256", CountryCode = "UG" },
                new UserTelephoneCountry { Id = 182, CountryName = "Ukraine", CountryDialCode = "+380", CountryCode = "UA" },
                new UserTelephoneCountry { Id = 183, CountryName = "United Arab Emirates", CountryDialCode = "+971", CountryCode = "AE" },
                new UserTelephoneCountry { Id = 184, CountryName = "United Kingdom", CountryDialCode = "+44", CountryCode = "GB" },
                new UserTelephoneCountry { Id = 185, CountryName = "United States", CountryDialCode = "+1", CountryCode = "US" },
                new UserTelephoneCountry { Id = 186, CountryName = "Uruguay", CountryDialCode = "+598", CountryCode = "UY" },
                new UserTelephoneCountry { Id = 187, CountryName = "Uzbekistan", CountryDialCode = "+998", CountryCode = "UZ" },
                new UserTelephoneCountry { Id = 188, CountryName = "Vanuatu", CountryDialCode = "+678", CountryCode = "VU" },
                new UserTelephoneCountry { Id = 189, CountryName = "Vatican City", CountryDialCode = "+39", CountryCode = "VA" },
                new UserTelephoneCountry { Id = 190, CountryName = "Venezuela", CountryDialCode = "+58", CountryCode = "VE" },
                new UserTelephoneCountry { Id = 191, CountryName = "Vietnam", CountryDialCode = "+84", CountryCode = "VN" },
                new UserTelephoneCountry { Id = 192, CountryName = "Yemen", CountryDialCode = "+967", CountryCode = "YE" },
                new UserTelephoneCountry { Id = 193, CountryName = "Zambia", CountryDialCode = "+260", CountryCode = "ZM" },
                new UserTelephoneCountry { Id = 194, CountryName = "Zimbabwe", CountryDialCode = "+263", CountryCode = "ZW" });
        }
    }
}
