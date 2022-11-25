using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidatior:AbstractValidator<Contact>
    {
        public ContactValidatior()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Lütfen mail adresinizi giriniz...");

            RuleFor(x => x.ContactSubject).NotEmpty().WithMessage("Lütfen konuyu giriniz...");
            RuleFor(x => x.ContactSubject).MinimumLength(3).WithMessage("Mesaj konusu 3 karakterden az olamaz...");
            RuleFor(x => x.ContactSubject).MaximumLength(50).WithMessage("Mesaj konusu 50 karakterden fazla olamaz...");

            RuleFor(x => x.ContactMessage).NotEmpty().WithMessage("Lütfen mesaj içeriğini giriniz...");
            RuleFor(x => x.ContactMessage).MinimumLength(3).WithMessage("Mesaj içeriği 3 karakterden az olamaz...");
            RuleFor(x => x.ContactMessage).MaximumLength(200).WithMessage("Mesaj içeriği 200 karakterden fazla olamaz...");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Lütfen kullanıcı adınızı giriniz...");

        }
    }
}
