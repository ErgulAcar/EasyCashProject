using DtoLayer.DTOs.AppUserDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MimeKit;
using System.Net.Mail;

namespace PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {//ıdentity kütüphanesinde şifre
            //en az 6 karakterden oluşulacak, en az bir büyük, bir küçük, 1 sembol, 1 sayı olmalı tabiki esnetilebilir yada dahada katılaşabilir.

            if (ModelState.IsValid)
            {
                Random random = new Random();
                var code = random.Next(100000, 999999);
                AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDto.Username,
                    Email = appUserRegisterDto.Email,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    ConfirmCode = code
                    
                };

                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                if (result.Succeeded)
                {
                    try
                    {
                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                        client.UseDefaultCredentials = false;
                        client.Credentials = new System.Net.NetworkCredential("onlineegitimplatformu1@gmail.com", "senyongsgchrgnvd");
                        client.EnableSsl = true;

                        MailMessage mailMessage = new MailMessage();
                        mailMessage.From = new MailAddress("onlineegitimplatformu1@gmail.com", "Easy Cash Admin");
                        mailMessage.To.Add(appUser.Email);
                        mailMessage.Subject = "Easy Cash Onay Kodu";
                        mailMessage.Body = "Kayıt işlemini gerçekleştimek için onay kodunuz : " + code;

                        client.Send(mailMessage);

                        TempData["Mail"] = appUser.Email;
                        
                        return RedirectToAction("Index", "ConfirmMail");
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View();
        }
    }
}
