using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
