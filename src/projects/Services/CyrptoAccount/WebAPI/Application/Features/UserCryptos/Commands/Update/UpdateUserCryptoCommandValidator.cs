﻿using FluentValidation;

namespace WebAPI.Application.Features.UserCryptos.Commands.Update
{
    public class UpdateUserCryptoCommandValidator : AbstractValidator<UpdateUserCryptoCommand>
    {
        public UpdateUserCryptoCommandValidator()
        {
            RuleFor(x => x.CryptoUrl).NotEmpty().WithMessage("CryptoUrl boş olamaz!");
            RuleFor(x => x.CryptoUrl).MinimumLength(2).WithMessage("CryptoUrl en az 2 karakterli olmalidir!");
        }
    }
}
