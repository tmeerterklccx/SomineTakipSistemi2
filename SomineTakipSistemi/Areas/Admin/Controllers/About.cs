using Microsoft.AspNetCore.Mvc;

namespace SomineTakipSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class About : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
