using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Areas.Admin.Controllers
{
    public class CategoryController1 : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
