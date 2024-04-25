using DataAccess.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace SomineTakipSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {

        public IActionResult Index()
        {
            using var context = new Context();
            var values = context.Users.ToList();
            return View(values);
        }
        public IActionResult Delete(int id)
        {
            using var context = new Context();
            var values = context.Users.Find(id);
            context.Users.Remove(values);
            return RedirectToAction("Index","User");

        }
    }
}
