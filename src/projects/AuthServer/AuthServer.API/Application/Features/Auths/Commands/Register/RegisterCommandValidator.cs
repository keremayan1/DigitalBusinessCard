using Core.Security.Dtos;
using FluentValidation;

namespace AuthServer.API.Application.Features.Auths.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.UserForRegisterDto.Password).MinimumLength(8)
                                  .WithMessage("Şifre En Az 8 Karakter Uzunluğunda Olmalıdır!")
                                  .Must(x =>
                                        x.Any(c => char.IsUpper(c) &&
                                        x.Any(c => char.IsLower(c)) &&
                                        x.Any(c => char.IsDigit(c))))
                                  .WithMessage("Şifre En az bir büyük harf, bir küçük harf ve bir rakam içermelidir!");
                                  

        }
    }
}
