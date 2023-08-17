using FluentValidation;

namespace WebAPI.Application.Features.Cryptos.Commands.Add
{
    public class CreateCryptoCommandValidator : AbstractValidator<CreateCryptoCommand>
    {
        public CreateCryptoCommandValidator()
        {
            RuleFor(x=>x.CryptoName).NotEmpty().WithMessage("Kripto İsmi Boş Olamaz!");
            RuleFor(x => x.CryptoName).MinimumLength(2).WithMessage("Kripto ismi minimum 2 karakter olmalıdır!");
        }
    }
}
