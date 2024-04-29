using Business.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SomineTakipSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var list = _aboutService.TGetList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Add()
        {    
            return View();
        }
        [HttpPost]
        public IActionResult Add(About about)
        {
            _aboutService.TInsert(about);
            return RedirectToAction("Index", "About","Admin");
        }
        public IActionResult Delete(int id)
        {
            var value = _aboutService.TGetByID(id);
            _aboutService.TDelete(value);
            return RedirectToAction("Index", "About", "Admin");
        }
        public IActionResult Update(int id)
        {
            using var context = new Context();
            var deger = context.Abouts.Find(id);
            var value = _aboutService.TGetByID(id);
            ViewBag.HeadText = value.HeadText;
            ViewBag.Description = value.Description;
            return View(deger);
        }
        [HttpPost]
        public IActionResult Update(int id,About about)
        {
            var value = _aboutService.TGetByID(id);
            value.HeadText = about.HeadText;
            value.Description = about.Description;
            
            _aboutService.TUpdate(value);
            return RedirectToAction("Index", "About", "Admin");
        }
    }
}
