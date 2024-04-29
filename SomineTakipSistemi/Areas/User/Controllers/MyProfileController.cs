using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SomineTakipSistemi.Areas.User.Controllers
{
    [Area("User")]
    
    public class MyProfileController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public MyProfileController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _signInManager.UserManager.GetUserAsync(User);
                ViewBag.userName = user.UserName;
                ViewBag.Email = user.Email;
                ViewBag.Number = user.PhoneNumber;
                return View();
            }
            return RedirectToAction("Login","Auth");
        }
    }
}
