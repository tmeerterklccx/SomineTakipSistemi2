using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SomineTakipSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestiMonialController : Controller
    {
        private readonly ITestiMonialService _testiMonialService;

        public TestiMonialController(ITestiMonialService testiMonialService)
        {
            _testiMonialService = testiMonialService;
        }

        public IActionResult Index()
        {
            var values = _testiMonialService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(TestiMonial testiMonial)
        {
            _testiMonialService.TInsert(testiMonial);
            return RedirectToAction("Index", "TestiMonial", "Admin");
        }
        public IActionResult Delete(int id)
        {
            var value = _testiMonialService.TGetByID(id);
            _testiMonialService.TDelete(value);
            return RedirectToAction("Index", "TestiMonial", "Admin");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _testiMonialService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(int id, TestiMonial testiMonial)
        {
            var value = _testiMonialService.TGetByID(id);
            value.Name = testiMonial.Name;
            value.CustomerImage = testiMonial.CustomerImage;
            value.FeedBackText = testiMonial.FeedBackText;
            _testiMonialService.TUpdate(value);
            return RedirectToAction("Index", "TestiMonial", "Admin");
        }
    }
}
