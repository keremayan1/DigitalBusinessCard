using Application.Features.UserSocialMedias.Commands.Add;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedias.Commands.Update
{
    public class UpdateUserSocialMediaCommandValidator : AbstractValidator<UpdateUserSocialMediaCommand>
    {
        public UpdateUserSocialMediaCommandValidator()
        {
            RuleFor(x => x.SocialMediaUrl).NotEmpty().WithMessage("Sosyal Medya URL boş olamaz!");
            RuleFor(x => x.SocialMediaId).NotEmpty().WithMessage("Lütfen boşluğu doldurun");
        }
    }
}
