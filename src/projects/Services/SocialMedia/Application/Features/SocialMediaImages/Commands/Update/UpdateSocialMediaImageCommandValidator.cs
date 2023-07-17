using Application.Features.SocialMediaImages.Commands.Add;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMediaImages.Commands.Update
{
    public class UpdateSocialMediaImageCommandValidator : AbstractValidator<UpdateSocialMediaImageCommand>
    {
        public UpdateSocialMediaImageCommandValidator()
        {
            RuleFor(x => x.File).NotEmpty().WithMessage("Dosya Ekleme Kısmı Boş Olamaz!");
            RuleFor(x => x.SocialMediaId).NotEmpty().WithMessage("Sosyal Medya Id Boş Olamaz!");
        }
    }
}
