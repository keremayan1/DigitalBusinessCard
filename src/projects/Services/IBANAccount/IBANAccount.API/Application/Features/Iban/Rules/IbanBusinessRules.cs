using IBANAccount.API.Domain.Entities;

namespace IBANAccount.API.Application.Features.Iban.Rules
{
    public class IbanBusinessRules
    {
        public void ToUpper(Domain.Entities.Iban iban)
        {
            iban.Code = iban.Code.ToUpper();
            iban.Country = iban.Country.ToUpper();
        }
        public void Trim(Domain.Entities.Iban iban)
        {
            iban.Code = iban.Code.Trim();
            iban.Country = iban.Country.Trim();
        }
    }
}
