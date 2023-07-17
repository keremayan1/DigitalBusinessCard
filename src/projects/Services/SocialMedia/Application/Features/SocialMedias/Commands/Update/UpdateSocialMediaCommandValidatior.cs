using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Commands.Update
{
    public class UpdateSocialMediaCommandValidatior : AbstractValidator<UpdateSocialMediaCommand>
    {
        public UpdateSocialMediaCommandValidatior()
        {
            RuleFor(c => c.SocialMediaName).NotEmpty().WithMessage("Sosyal Medya Ismi boş olamaz!");
        }
    }
}
