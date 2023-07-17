using FluentValidation;

namespace Application.Features.Games.Commands.Add
{
    public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
    {
        public CreateGameCommandValidator()
        {
            RuleFor(x => x.GameName).NotEmpty().WithMessage("Oyun İsmi Boş Olamaz!");
        }
    }
}
