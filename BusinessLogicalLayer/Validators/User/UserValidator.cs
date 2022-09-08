using FluentValidation;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Validators.User
{
    internal class UserValidator : AbstractValidator<Entities.UserS.User>
    {
        public void ValidateID()
        {
            RuleFor(u => u.Id)
                .NotNull().WithMessage(LocationConstants.IdNotNullMessage);
        }

        public void ValidateNickname()
        {
            RuleFor(u => u.Nickname)
                .NotNull().WithMessage(LocationConstants.Nickname.NotNullMessage)
                .MinimumLength(LocationConstants.Nickname.MinLength).WithMessage(LocationConstants.Nickname.MinLengthMessage)
                .MaximumLength(LocationConstants.Nickname.MaxLength).WithMessage(LocationConstants.Nickname.MaxLengthMessage);
        }

        public void ValidateEmail()
        {
            RuleFor(u => u.Email)
                .EmailAddress(); //so confere @ mas...
        }

        public void ValidatePassword()
        {
            RuleFor(u => u.Password)
                .NotNull().WithMessage(LocationConstants.Password.NotNullMessage)
                .MinimumLength(LocationConstants.Password.MinLength).WithMessage(LocationConstants.Password.MinLengthMessage)
                .MaximumLength(LocationConstants.Password.MaxLength).WithMessage(LocationConstants.Password.MaxLengthMessage)
                .Must(CommonValidations.HasValidPassword).WithMessage(LocationConstants.Password.InvalidPasswordMessage);
        }

        public void ValidateConfirmPassword()
        {
            RuleFor(u => u.ConfirmPassword)
               .Equal(u => u.Password).WithMessage(LocationConstants.Password.ConfirmPasswordMessage);
        }
    }
}
