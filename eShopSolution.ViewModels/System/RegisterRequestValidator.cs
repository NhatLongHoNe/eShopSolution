using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.System
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required")
                .MaximumLength(200).WithMessage("First name can not over 200 characters");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required")
                .MaximumLength(200).WithMessage("Last name can not over 200 characters");

            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Birthday cannot greater than 100 years");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email format not match");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required")
                .Matches(@"^(([+]{0,1}\d{2})|\d?)[\s-]?[0-9]{2}[\s-]?[0-9]{3}[\s-]?[0-9]{4}$")
                .WithMessage("Phone is not match");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password is at least 6 characters");

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Confirm password is not match");
                }
            });
        }
    }
}
