using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace SomineTakipSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            var values = _orderService.TGetList();
            return View(values);
        }
        public IActionResult Delete(int id)
        {
            var value = _orderService.TGetByID(id);
            _orderService.TDelete(value);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatus(int id)
        {
            var value = _orderService.TGetByID(id);
            if (value.Statu == false)
            {
                value.Statu = true;
                var user = _orderService.TGetByID(id);
                var userMail = user.UserMail;
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("info@devmert.com.tr");
                    mail.To.Add(userMail);
                    mail.Subject = "PROMETHEUS ŞÖMİNE";
                    mail.Body = "<h1>PROMETHEUS ŞÖMİNE SİPARİŞİNİZİ ONAYLADI!</h1>";
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("mail.devmert.com.tr", 587))
                    {
                        smtp.Credentials = new NetworkCredential("info@devmert.com.tr", "123456Mert!!Xx");
                        smtp.UseDefaultCredentials = false;
                        smtp.EnableSsl = false;
                        smtp.Send(mail);
                    }
                }
            }
            else
            {
                value.Statu = false;
                var user = _orderService.TGetByID(id);
                var userMail = user.UserMail;
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("info@devmert.com.tr");
                    mail.To.Add(userMail);
                    mail.Subject = "PROMETHEUS ŞÖMİNE";
                    mail.Body = "<h1>PROMETHEUS ŞÖMİNE SİPARİŞİNİZİ ONAYLAMADI!</h1>";
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("mail.devmert.com.tr", 587))
                    {
                        smtp.Credentials = new NetworkCredential("info@devmert.com.tr", "123456Mert!!Xx");
                        smtp.UseDefaultCredentials = false;
                        smtp.EnableSsl = false;
                        smtp.Send(mail);
                    }
                }

            }
            _orderService.TUpdate(value);
            return RedirectToAction("Index");
        }

    }
}
