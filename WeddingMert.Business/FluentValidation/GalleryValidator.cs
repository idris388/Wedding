using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Entity.Concrete;

namespace WeddingMert.Business.FluentValidation
{
    public class GalleryValidator : AbstractValidator<Gallery>
    {
        public GalleryValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithName("Başlık");
        }
    }
}
