using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SomineTakipSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServicesController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var values = _serviceService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(Service service)
        {
            _serviceService.TInsert(service);
            return RedirectToAction("Index", "Services", "Admin");
        }
        public IActionResult Delete(int id)
        {
            var value = _serviceService.TGetByID(id);
            _serviceService.TDelete(value);
            return RedirectToAction("Index", "Services", "Admin");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _serviceService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(int id, Service service)
        {
            var value = _serviceService.TGetByID(id);
            value.Description = service.Description;
            value.Name = service.Name;
            _serviceService.TUpdate(value);
            return RedirectToAction("Index", "Services", "Admin");
        }
    }
}
