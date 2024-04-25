using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace SomineTakipSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class OurInfoController : Controller
    {
        private readonly IOurInfoService _service;

        public OurInfoController(IOurInfoService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var values = _service.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(OurInfo info)
        {
            _service.TInsert(info);
            return RedirectToAction("Index", "OurInfo", "Admin");
        }
        public IActionResult Delete(int id)
        {
            var value = _service.TGetByID(id);
            _service.TDelete(value);
            return RedirectToAction("Index", "OurInfo", "Admin");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _service.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(int id, OurInfo info)
        {
            var value = _service.TGetByID(id);
            value.BottomText = info.BottomText;
            value.ImageLink = info.ImageLink;
            value.HeadText = info.HeadText;
            _service.TUpdate(value);
            return RedirectToAction("Index", "OurInfo", "Admin");
        }
    }
}
