using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ImagesValidator : AbstractValidator<Images>
    {
        public ImagesValidator()
        {
            RuleFor(p => p.CarId).NotEmpty();
            RuleFor(p => p.ImagePath).NotEmpty();
            RuleFor(p => p.ImagePath).NotNull();
        }
    }
}
