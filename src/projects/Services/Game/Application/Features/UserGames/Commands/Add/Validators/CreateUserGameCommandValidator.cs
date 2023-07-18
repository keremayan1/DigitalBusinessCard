using FluentValidation;

namespace Application.Features.UserGames.Commands.Add.Validators
{
    public class CreateUserGameCommandValidator : AbstractValidator<CreateUserGameCommand>
    {
        public CreateUserGameCommandValidator()
        {
            RuleFor(x => x.GameId).NotEmpty().WithMessage("Game ID Alanı boş olamaz!");
            RuleFor(x => x.GameUrl).NotEmpty().WithMessage("Oyun URL Alanı boş olamaz!");
        }
    }
}
