using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(x => x.ImagePath).NotNull().WithMessage("Dosya alanı boş olamaz.");

            
        }
    }
}