using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace SomineTakipSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MainTopController : Controller
    {
        private readonly IMainTopService _mainTopService;

        public MainTopController(IMainTopService mainTopService)
        {
            _mainTopService = mainTopService;
        }

        public IActionResult Index()
        {
            var values = _mainTopService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(MainTop mainTop)
        {
            _mainTopService.TInsert(mainTop);
            return RedirectToAction("Index", "MainTop", "Admin");
        }
        public IActionResult Delete(int id)
        {
            var value = _mainTopService.TGetByID(id);
            _mainTopService.TDelete(value);
            return RedirectToAction("Index", "MainTop", "Admin");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _mainTopService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(int id, MainTop mainTop)
        {
            var value = _mainTopService.TGetByID(id);
            value.BottomText = mainTop.BottomText;
            value.HeadText = mainTop.HeadText;
            _mainTopService.TUpdate(value);
            return RedirectToAction("Index", "MainTop", "Admin");
        }
    }
}
