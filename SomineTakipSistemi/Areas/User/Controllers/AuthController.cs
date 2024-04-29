using Microsoft.AspNetCore.Mvc;

namespace SomineTakipSistemi.Areas.User.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return RedirectToAction("Index","Default");
        }
    }
}
