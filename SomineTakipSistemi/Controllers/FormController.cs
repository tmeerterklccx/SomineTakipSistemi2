using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SomineTakipSistemi.Controllers
{
    public class FormController : Controller
    {
        private readonly SignInManager<AppUser> 
            _signInManager;

        public FormController(SignInManager<AppUser> sign)
        {
            _signInManager = sign;
        }

        public async Task<IActionResult> Index(int id)
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _signInManager.UserManager.GetUserAsync(User);
                ViewBag.Email = user.Email;
                using var context = new Context();
                var product =context.Products.Find(id);
                ViewBag.ProductName = product.ProductName;
                return View();
            }
            return View();
        }
    }
}
