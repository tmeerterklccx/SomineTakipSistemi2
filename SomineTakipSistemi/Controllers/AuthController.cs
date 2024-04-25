using Entity.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SomineTakipSistemi.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AppUser model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.PasswordHash, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
            }
            ViewBag.User = "Hatalı kullanıcı adı veya şifre";
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Register(AppUser appUser)
        {
            ViewBag.v1 = "";
            if (!ModelState.IsValid)
            {
                return View(appUser);
            }
            var result = await _userManager.CreateAsync(appUser, appUser.PasswordHash);
            ViewBag.v1 = "Kayıt Başarıyla Oluşturuldu";
            if (!result.Succeeded)
            {
                ViewBag.v1 = "Kayıt Başarısız!";
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View(appUser);
            }
            await _userManager.AddToRoleAsync(appUser, "NormalUser");

            return View("Register","Auth");
            
        }
        public async  Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login","Auth");
        }
    }
}
