using Application.Features.UserGames.Commands.Add;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserGames.Commands.Update
{
    public class UpdateUserGameCommandValidator : AbstractValidator<UpdateUserGameCommand>
    {
        public UpdateUserGameCommandValidator()
        {
            RuleFor(x => x.GameId).NotEmpty().WithMessage("Game ID Alanı boş olamaz!");
            RuleFor(x => x.GameUrl).NotEmpty().WithMessage("Oyun URL Alanı boş olamaz!");
        }
    }
}
