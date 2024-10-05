using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, false, true);//ilki false hatırlansınmı bilgiler, true ise kullanıcı laglansınmı belli bir denemede
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginViewModel.Username);
                if (user.EmailConfirmed == true)
                {
                    return RedirectToAction("Index", "MyAccounts");

                }
                //else lütfem mail adresinizi onaylayın
            }
            // kullanıcı adı veya şifre hattalı
            return View();
        }
    }
}
