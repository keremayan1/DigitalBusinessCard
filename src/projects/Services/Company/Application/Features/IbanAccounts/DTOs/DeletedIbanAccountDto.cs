namespace Application.Features.IbanAccounts.DTOs
{
    public class DeletedIbanAccountDto
    {
        public int Id { get; set; }
        public int BankIbanAccountId { get; set; }
        public string IbanUserName { get; set; }
        public string IbanNumber { get; set; }
    }
}
