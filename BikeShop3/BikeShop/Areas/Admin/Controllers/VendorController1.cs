using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VendorController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
