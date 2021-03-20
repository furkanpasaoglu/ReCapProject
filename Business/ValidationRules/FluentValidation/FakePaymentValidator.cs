using System;
using Core.Entities.Concrete.Fake;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class FakePaymentValidator : AbstractValidator<FakeCreditCardModel>
    {
        public FakePaymentValidator()
        {
            RuleFor(f => f.CardNumber).NotEmpty()
                .MinimumLength(16).MaximumLength(16);

            RuleFor(f => f.CardHolderName).NotEmpty()
                .MaximumLength(50);

            RuleFor(f => f.ExpirationMonth).NotEmpty()
                .LessThan(13).GreaterThan(0);

            RuleFor(f => f.Cvv).NotEmpty()
                .MinimumLength(3).MaximumLength(3);

            RuleFor(p => p.ExpirationYear).NotEmpty()
                .LessThan(DateTime.Now.AddYears(30).Year).GreaterThan(DateTime.Now.Year);
        }
    }
}