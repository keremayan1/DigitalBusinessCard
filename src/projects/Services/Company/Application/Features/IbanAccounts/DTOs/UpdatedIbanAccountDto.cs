namespace Application.Features.IbanAccounts.DTOs
{
    public class UpdatedIbanAccountDto
    {
        public int Id { get; set; }
        public int IbanInfoId { get; set; }
        public string IbanUserName { get; set; }
        public string IbanNumber { get; set; }
    }
}
