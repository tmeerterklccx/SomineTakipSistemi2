using Business.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SomineTakipSistemi.Controllers
{
    public class DefaultController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult birinciPart()
        {

            using var context = new Context();
            var values = context.MainTops.ToList();
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
