using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TMP2019.Models;

namespace TMP2019.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Lists()
        {
            return View();
        }

        public IActionResult Links()
        {
            return View();
        }

        public IActionResult Stats()
        {
            return View();
        }

        public IActionResult TMPHockey()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin")) return RedirectToAction("TMPHockey", "Admin");
                else
                    return RedirectToAction("Index", "Guest");
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
