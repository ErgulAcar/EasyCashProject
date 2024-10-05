using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DtoLayer.DTOs.AppUserDtos;

namespace PresentationLayer.Controllers
{
    [Authorize]
    public class MyAccountsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MyAccountsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserEditDto appUserEditDto = new AppUserEditDto()
            {
                Name = values.Name,
                Surname = values.Surname,
                District = values.District,
                City = values.city,
                ImageUrl = values.ImageUrl,
                PhoneNumber = values.PhoneNumber,
                Email = values.Email,

            };

            return View(appUserEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditDto appUserEditDto)
        {
            if (appUserEditDto.Password == appUserEditDto.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = appUserEditDto.Name;
                user.Surname = appUserEditDto.Surname;
                user.District = appUserEditDto.District;
                user.city = appUserEditDto.City;
                user.ImageUrl = appUserEditDto.ImageUrl;
                user.PhoneNumber = appUserEditDto.PhoneNumber;
                user.Email = appUserEditDto.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDto.Password);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            
            return View(appUserEditDto);
        }


    }
}
