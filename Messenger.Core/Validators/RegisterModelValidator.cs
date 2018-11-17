using Messenger.Core.RequestModels;
using FluentValidation;
using System;
using System.Linq;

namespace Messenger.Core.Validators
{
    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        public RegisterModelValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("Email was not provided");
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Wrong format for email address");
            RuleFor(x => x.FirstName)
                .NotNull()
                .WithMessage("First name was not provided");
            RuleFor(x => x.LastName)
               .NotNull()
               .WithMessage("Last name was not provided");
            //RuleFor(x => x.Password)
            //    .MinimumLength(8)
            //    .WithMessage("Password must be at least 8 characters long");
            //RuleFor(x => x.Password)
            //    .Must(x => x.Any(Char.IsLower) && x.Any(Char.IsUpper) && x.Any(Char.IsNumber))
            //    .WithMessage("Password requirements weren't fulfilled");
        }
    }
}
