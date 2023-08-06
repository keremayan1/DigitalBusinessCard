namespace IBANAccount.API.Application.Features.UserIbans.DTOs
{
    public class UpdatedUserIbanDto
    {
        public int Id { get; set; }
        public int IbanId { get; set; }
        public int UserId { get; set; }
       
        public string IbanNumber { get; set; }
    }
}
