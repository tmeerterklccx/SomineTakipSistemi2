﻿using Microsoft.AspNetCore.Mvc;

namespace SomineTakipSistemi.Areas.Admin.Controllers
{
    public class GetContact : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}