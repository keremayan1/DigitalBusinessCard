using Application.Features.GameImages.Commands.Add;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GameImages.Commands.Update
{
    public class UpdateGameImageCommandValidator : AbstractValidator<UpdateGameImageCommand>
    {
        public UpdateGameImageCommandValidator()
        {
            RuleFor(x => x.GameId).NotEmpty().WithMessage("Game ID Alanı Boş Olamaz!");
            RuleFor(x => x.Photo).NotEmpty().WithMessage("Fotoğraf Alanı Boş Olamaz!");
        }
    }
}
