namespace Application.Features.IbanAccounts.DTOs
{
    public class GetByIbanAccountDto
    {
        public int Id { get; set; }
        public string IbanUserName { get; set; }
        public string IbanNameAndNumber { get; set; }
    }
}
