using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ImagesValidator : AbstractValidator<Images>
    {
        public ImagesValidator()
        {
            RuleFor(c => c.CarId).NotNull();
        }
    }
}
