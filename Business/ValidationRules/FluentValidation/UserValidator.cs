using System.Text.RegularExpressions;
using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("İsim boş geçilemez");
            RuleFor(u => u.FirstName).MinimumLength(2).WithMessage("İsim en az 2 karakterden oluşmalıdır");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Soyad boş geçilemez");
            RuleFor(u => u.LastName).MinimumLength(2).WithMessage("Soyad en az 2 karakterden oluşmalıdır");
            RuleFor(u => u.Email).NotEmpty().WithMessage("E-mail boş geçilemez");
            RuleFor(u => u.Email).EmailAddress().When( u=>!string.IsNullOrEmpty(u.Email));
            RuleFor(u => u.Email).Must(IsEmailValid);
        }
        private bool IsEmailValid(string arg)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(arg);
        }

    }
}
