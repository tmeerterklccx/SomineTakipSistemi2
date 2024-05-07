using Business.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SomineTakipSistemi.Controllers
{
    public class FormController : Controller
    {
        private readonly SignInManager<AppUser> 
            _signInManager;
        private readonly IOrderService
    _orderService;

        public FormController(SignInManager<AppUser> signInManager, IOrderService orderServic)
        {
            _signInManager = signInManager;
            _orderService = orderServic;
        }

        public async Task<IActionResult> Index(int id)
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _signInManager.UserManager.GetUserAsync(User);
                ViewBag.Email = user.Email;
                using var context = new Context();
                var product =context.Products.Find(id);
                ViewBag.ProductName = product.ProductName;
                return View();
            }
            return RedirectToAction("Login","Auth");
        }
        [HttpPost]
        public async Task<IActionResult> Index(int id,Order order)
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _signInManager.UserManager.GetUserAsync(User);
                order.UserMail = user.Email;
                order.Statu = false;
                using var context = new Context();
                var product = context.Products.Find(id);
                order.ProductName = product.ProductName;
                _orderService.TInsert(order);
                ViewBag.Onay = "Sipariş Bilgileriniz İletildi.";
                return View();
            }
            return RedirectToAction("Login", "Auth");
        }
    }
}
