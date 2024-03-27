using Microsoft.AspNetCore.Mvc;

namespace SomineTakipSistemi.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
