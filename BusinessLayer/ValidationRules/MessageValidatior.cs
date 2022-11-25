using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidatior:AbstractValidator<Message>
    {
        public MessageValidatior()
        {
            RuleFor(x => x.MessageReceiverMail).NotEmpty().WithMessage("Alıcının mail adresini giriniz...");
            RuleFor(x => x.MessageReceiverMail).MinimumLength(10).WithMessage("Alıcının mail adresini 3 karakterden az olamaz...");
            RuleFor(x => x.MessageReceiverMail).MaximumLength(100).WithMessage("Alıcının mail adresini 100 karakterden fazla olamaz...");

            //RuleFor(x => x.MessageSenderMail).NotEmpty().WithMessage("Gönderenin mail adresini giriniz...");
            //RuleFor(x => x.MessageSenderMail).MinimumLength(10).WithMessage("Gönderenin mail adresini 3 karakterden az olamaz...");
            //RuleFor(x => x.MessageSenderMail).MaximumLength(100).WithMessage("Gönderenin mail adresini 100 karakterden fazla olamaz...");


            RuleFor(x => x.MessageSubject).NotEmpty().WithMessage("Konuyu giriniz...");
            RuleFor(x => x.MessageSubject).MinimumLength(3).WithMessage("Konu 3 karakterden az olamaz...");
            RuleFor(x => x.MessageSubject).MaximumLength(50).WithMessage("Konu 50 karakterden fazla olamaz...");


            RuleFor(x => x.MessageDetails).NotEmpty().WithMessage("Mesajı giriniz...");
            RuleFor(x => x.MessageDetails).MinimumLength(10).WithMessage("Mesaj 10 karakterden az olamaz...");
            

        }
    }
}
