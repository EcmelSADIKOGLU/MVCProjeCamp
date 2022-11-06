using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidatior : AbstractValidator<Category>
    {
        public CategoryValidatior()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adını giriniz...");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori adı 3 karakterden az olamaz...");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Kategori adı 50 karakterden fazla olamaz");

            RuleFor(x=> x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklamasını giriniz...");
            RuleFor(x => x.CategoryDescription).MinimumLength(3).WithMessage("Kategori açıklamasını 3 karakterden az olamaz...");
            RuleFor(x => x.CategoryDescription).MaximumLength(200).WithMessage("Kategori açıklamasını 200 karakterden fazla olamaz...");

        }
    }
}
