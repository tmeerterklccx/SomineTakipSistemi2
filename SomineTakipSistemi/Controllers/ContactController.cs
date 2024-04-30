using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SomineTakipSistemi.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactInfoService _contactInfoService;
        private readonly IGetContactService _getContactService;

        public ContactController(IContactInfoService contactInfoService, IGetContactService getContactService)
        {
            _contactInfoService = contactInfoService;
            _getContactService = getContactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _contactInfoService.TGetList();
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(GetContact getContact)
        {
            _getContactService.TInsert(getContact);
            ViewBag.onay = "Başarıyla Gönderildi.";
            return View();
        }
    }
}
