using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace SomineTakipSistemi.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactInfoService _contactInfoService;

        public ContactController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _contactInfoService.TGetList();
            return View(values);
        }
    }
}
