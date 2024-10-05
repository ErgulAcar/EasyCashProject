using DtoLayer.DTOs.AppUserDtos;
using FluentValidation;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı alanı boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Sifre alanı boş geçilemez");
            RuleFor(x => x.Confirmpassword).NotEmpty().WithMessage("Şifre tekrarı alanı boş geçilemez");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter girişi yapın");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
            RuleFor(x => x.Confirmpassword).Equal(y=>y.Password).WithMessage("Parolanız eşleşmiyor");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Litfen geçerli bir mail giriniz");
        }
    }
}
