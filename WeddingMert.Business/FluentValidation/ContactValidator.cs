using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Entity.Concrete;

namespace WeddingMert.Business.FluentValidation
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x=>x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(50)
                .WithName("İsim");
            RuleFor(x => x.Surname)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(60)
                .WithName("Soyisim");
            RuleFor(x => x.Mail)
                .NotEmpty()
                .NotNull()
                .MinimumLength(10)
                .MaximumLength(100)
                .WithName("Mail");
            RuleFor(x => x.Phone)
                .NotEmpty()
                .NotNull()
                .MinimumLength(10)
                .MaximumLength(20)
                .WithName("Telefon");
            RuleFor(x => x.Message)
                .NotEmpty()
                .NotNull()
                .MinimumLength(1)
                .MaximumLength(400)
                .WithName("Mesajınız");
        }
    }
}
