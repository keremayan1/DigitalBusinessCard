using FluentValidation;
namespace Application.Features.SocialMedias.Commands.Add
{
    public class CreateSocialMediaCommandValidatior : AbstractValidator<CreateSocialMediaCommand>
    {
        public CreateSocialMediaCommandValidatior()
        {
            RuleFor(c => c.SocialMediaName).NotEmpty().WithMessage("Sosyal Medya Ismi boş olamaz!");
        }
    }
}
