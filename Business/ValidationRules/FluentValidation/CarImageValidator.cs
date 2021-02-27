using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(x => x.ImagePath).NotNull().WithMessage("Dosya alanı boş olamaz.");

            RuleFor(x => x.ImagePath.Length).LessThanOrEqualTo(1024 * 500)
                .WithMessage("Dosya boyutu en fazla 500kb olmalıdır.");
            
        }
    }
}