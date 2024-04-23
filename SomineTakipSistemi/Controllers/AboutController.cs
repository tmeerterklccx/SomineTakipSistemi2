using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace SomineTakipSistemi.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        { 
            var values = _aboutService.TGetList();
            return View(values);
        }
    }
}
