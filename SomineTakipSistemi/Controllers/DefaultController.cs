using Business.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SomineTakipSistemi.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IMainTopService _mainTopService;

        public DefaultController(IMainTopService mainTopService)
        {
            _mainTopService = mainTopService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task< PartialViewResult> birinciPart()
        {

            var context = new Context();
            var values =await context.MainTops.ToListAsync();
            return PartialView(values);
        }

        public PartialViewResult ikinciPart()
        {
            using var context = new Context();
            var values = context.ourInfos.ToList();
            return PartialView(values);
        }
        public PartialViewResult ucuncuPart()
        {
            using var context = new Context();
            var values = context.Services.ToList();
            return PartialView(values);
        }
    }
}
