using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SomineTakipSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GetContactController : Controller
    {
        private readonly IGetContactService _contactService;

        public GetContactController(IGetContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var values = _contactService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(GetContact contactInfo)
        {
            _contactService.TInsert(contactInfo);
            return RedirectToAction("Index", "GetContact", "Admin");
        }
        public IActionResult Delete(int id)
        {
            var value = _contactService.TGetByID(id);
            _contactService.TDelete(value);
            return RedirectToAction("Index", "GetContact", "Admin");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _contactService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(int id, GetContact contactInfo)
        {
            var value = _contactService.TGetByID(id);
            value.Subject = contactInfo.Subject;
            value.Number = contactInfo.Number;
            value.Message = contactInfo.Message;
            value.Name = contactInfo.Name;
            _contactService.TUpdate(value);
            return RedirectToAction("Index", "GetContact", "Admin");
        }
    }
}
