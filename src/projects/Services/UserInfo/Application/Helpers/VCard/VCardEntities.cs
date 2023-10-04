namespace Application.Helpers.VCard
{
    public static class VCardEntities
    {
        public const string NewLine = "\r\n";
        public const string Separator = ";";
        public const string Header = "BEGIN:VCARD\r\nVERSION:3.0";
        public const string Name = "N:";
        public const string FormattedName = "FN:";
        public const string OrganizationName = "ORG:";
        public const string TitlePrefix = "TITLE:";
        public const string PhotoPrefix = "PHOTO;ENCODING=BASE64;JPEG:";
        public const string PhonePrefix = "TEL;TYPE=";
        public const string PhoneSubPrefix = ",VOICE:";
        public const string AddressPrefix = "ADR;TYPE=";
        public const string AddressSubPrefix = "PREF:;;";
        public const string EmailPrefix = "EMAIL;TYPE=";
        public const string EmailSubPrefix = "PREF:";
        public const string Footer = "END:VCARD";
        public const string WorkType = "work,";
        public const string HomeType = "home,";
        public const string SchoolType = "school,";
        public const string CellType = "cell,";

    }
}
