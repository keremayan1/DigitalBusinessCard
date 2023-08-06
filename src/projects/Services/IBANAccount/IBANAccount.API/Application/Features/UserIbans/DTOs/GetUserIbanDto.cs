namespace IBANAccount.API.Application.Features.UserIbans.DTOs
{
    public class GetUserIbanDto
    {
        public int Id { get; set; }
        public int IbanId { get; set; }
        public string IbanUserName { get; set; }
        public string IbanNameAndNumber { get; set; }
       
    }
}
