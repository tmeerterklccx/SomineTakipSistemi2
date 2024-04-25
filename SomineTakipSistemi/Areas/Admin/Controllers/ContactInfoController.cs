using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace SomineTakipSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactInfoController : Controller
    {
        private readonly IContactInfoService _contactInfoService;

        public ContactInfoController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        
        public IActionResult Index()
        {
            var values = _contactInfoService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(ContactInfo contactInfo)
        {
            _contactInfoService.TInsert(contactInfo);
            return RedirectToAction("Index", "ContactInfo", "Admin");
        }
        public IActionResult Delete(int id)
        {
            var value = _contactInfoService.TGetByID(id);
            _contactInfoService.TDelete(value);
            return RedirectToAction("Index", "ContactInfo", "Admin");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _contactInfoService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(int id, ContactInfo contactInfo)
        {
            var value = _contactInfoService.TGetByID(id);
            value.MapLocation = contactInfo.MapLocation;
            value.Address = contactInfo.Address;
            value.Number = contactInfo.Number;
            value.BottomText = contactInfo.BottomText;
            value.HeadText = contactInfo.HeadText;
            value.MapLocation= contactInfo.MapLocation;
            value.EMail = contactInfo.EMail;
            _contactInfoService.TUpdate(value);
            return RedirectToAction("Index", "ContactInfo", "Admin");
        }
    }
}
