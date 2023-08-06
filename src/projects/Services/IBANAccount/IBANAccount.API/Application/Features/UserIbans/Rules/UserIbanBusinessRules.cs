using IBANAccount.API.Domain.Entities;

namespace IBANAccount.API.Application.Features.UserIbans.Rules
{
    public class UserIbanBusinessRules
    {
        public void ToUpper(UserIban userIban)
        {
            userIban.IbanUserName = userIban.IbanUserName.ToUpper();
        }
        public void Trim(UserIban userIban)
        {
            userIban.IbanUserName = userIban.IbanUserName.Trim();
        }
    }
}
