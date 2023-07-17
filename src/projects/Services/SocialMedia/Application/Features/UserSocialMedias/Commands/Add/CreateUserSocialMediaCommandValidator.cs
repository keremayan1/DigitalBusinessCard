using FluentValidation;

namespace Application.Features.UserSocialMedias.Commands.Add
{
    public class CreateUserSocialMediaCommandValidator : AbstractValidator<CreateUserSocialMediaCommand>
    {
        public CreateUserSocialMediaCommandValidator()
        {
            RuleFor(x => x.SocialMediaUrl).NotEmpty().WithMessage("Sosyal Medya URL boş olamaz!");
            RuleFor(x => x.SocialMediaId).NotEmpty().WithMessage("Lütfen boşluğu doldurun");
        }
    }
}
