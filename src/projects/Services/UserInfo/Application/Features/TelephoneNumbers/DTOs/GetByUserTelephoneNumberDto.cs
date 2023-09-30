namespace Application.Features.TelephoneNumbers.DTOs
{
    public class GetByUserTelephoneNumberDto
    {
        public int Id { get; set; }
        public string TelephoneCountryDialCode { get; set; }
        public string TelephoneType { get; set; }
        public string TelephoneNumber { get; set; }
    }


}
