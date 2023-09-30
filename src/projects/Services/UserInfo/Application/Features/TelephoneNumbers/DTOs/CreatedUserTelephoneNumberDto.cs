namespace Application.Features.TelephoneNumbers.DTOs
{
    public class CreatedUserTelephoneNumberDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int UserTelephoneTypeId { get; set; }
        public int UserTelephoneCountryId { get; set; }
        public string TelephoneNumber { get; set; }
    }


}
