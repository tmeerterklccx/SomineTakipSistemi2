using Microsoft.AspNetCore.Mvc;

namespace SomineTakipSistemi.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
