using FluentValidation;

namespace Application.Features.SocialMediaImages.Commands.Add
{
    public class CreateSocialMediaImageCommandValidator : AbstractValidator<CreateSocialMediaImageCommand>
    {
        public CreateSocialMediaImageCommandValidator()
        {
            RuleFor(x => x.File).NotEmpty().WithMessage("Dosya Ekleme Kısmı Boş Olamaz!");
            RuleFor(x => x.SocialMediaId).NotEmpty().WithMessage("Sosyal Medya Id Boş Olamaz!");
        }
    }
}
