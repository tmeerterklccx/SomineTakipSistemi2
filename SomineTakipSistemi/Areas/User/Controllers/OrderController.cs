using Microsoft.AspNetCore.Mvc;

namespace SomineTakipSistemi.Areas.User.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
