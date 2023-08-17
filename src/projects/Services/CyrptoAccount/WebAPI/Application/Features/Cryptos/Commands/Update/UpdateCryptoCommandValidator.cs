using FluentValidation;

namespace WebAPI.Application.Features.Cryptos.Commands.Update
{
    public class UpdateCryptoCommandValidator : AbstractValidator<UpdateCryptoCommand>
    {
        public UpdateCryptoCommandValidator()
        {
            RuleFor(x => x.CryptoName).NotEmpty().WithMessage("Kripto İsmi Boş Olamaz!");
            RuleFor(x => x.CryptoName).MinimumLength(2).WithMessage("Kripto ismi minimum 2 karakter olmalıdır!");
        }
    }
}
