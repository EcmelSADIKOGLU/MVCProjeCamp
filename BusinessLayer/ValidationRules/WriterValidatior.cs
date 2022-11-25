using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidatior: AbstractValidator<Writer>
    {
        public WriterValidatior()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını giriniz...");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar adı 2 karakterden az olamaz...");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Yazar adı 50 karakterden fazla olamaz...");

            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını giriniz...");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Yazar soyadı 2 karakterden az olamaz...");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Yazar soyadı 50 karakterden fazla olamaz...");

            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar hakkındasını giriniz...");
            RuleFor(x => x.WriterAbout).MinimumLength(2).WithMessage("Yazar hakkındası 2 karakterden az olamaz...");
            RuleFor(x => x.WriterAbout).MaximumLength(100).WithMessage("Yazar hakkındası 100 karakterden fazla olamaz...");

            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar mailini giriniz...");
            RuleFor(x => x.WriterMail).MinimumLength(2).WithMessage("Yazar maili 2 karakterden az olamaz...");
            RuleFor(x => x.WriterMail).MaximumLength(200).WithMessage("Yazar maili 200 karakterden fazla olamaz...");

        }
    }
}
