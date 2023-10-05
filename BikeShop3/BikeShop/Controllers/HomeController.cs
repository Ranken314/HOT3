using BikeShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}