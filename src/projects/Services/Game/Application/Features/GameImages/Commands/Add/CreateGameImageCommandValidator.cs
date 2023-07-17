using FluentValidation;

namespace Application.Features.GameImages.Commands.Add
{
    public class CreateGameImageCommandValidator : AbstractValidator<CreateGameImageCommand>
    {
        public CreateGameImageCommandValidator()
        {
            RuleFor(x => x.GameId).NotEmpty().WithMessage("Game ID Alanı Boş Olamaz!");
            RuleFor(x => x.Photo).NotEmpty().WithMessage("Fotoğraf Alanı Boş Olamaz!");
        }
    }

}
