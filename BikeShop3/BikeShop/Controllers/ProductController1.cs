using BikeShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers
{
    [Route("Product/[controller]/[action]/{id?}")]
    public class ProductController : Controller
    {
        // Declare private context variable
        private BikeShopContext Context { get; set; }

        // Constructor
        public ProductController(BikeShopContext ctx)
        {
            Context = ctx;
        }

        //List all Product
        public IActionResult List()
        {
            List<Product> products = Context.Products
                                            .Include(c => c.Category)
                                            .OrderBy(p => p.Name)
                                            .ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Category = Context.Categories
                                      .OrderBy(c => c.CategoryName)
                                      .ToList();

            return View("AddEdit", new Product());
        }
        [HttpGet]

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            // Find the desired product to update
            var product = Context.Products.Find(id);

            //  "Fill Up" the fields
            ViewBag.Category = Context.Categories
                                      .OrderBy(c => c.CategoryName)
                                      .ToList();

            return View("AddEdit", product);
        }

        [HttpPost]
        // Either add a new product to the database or
        // Update an existing product in the database
        public IActionResult Save(Product product)
        {
            // Verify that the ModelState is Valid
            if (ModelState.IsValid)
            {
                if (product.ProductID == 0)
                {
                    // Check for Product ID == 0
                    // If it is, this is an Add
                    Context.Products.Add(product);
                }
                else
                {
                    // Otherwise, this is an Update.
                    Context.Products.Update(product);
                }

                // Regargless of whether this is an Add or an Update,
                // save the changes to the database and then
                // return to the product list ( can see changes).
                Context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                // Problem with the model validation
                ViewBag.Action = (product.ProductID == 0) ? "Add" : "Edit";

                ViewBag.Category = Context.Categories
                                     .OrderBy(c => c.CategoryName)
                                     .ToList();
            }
            return View("AddEdit", product);
        }

        [HttpGet]
        // Show the delete form
        public ActionResult Delete(int id)
        {
            // Find the product to delete
            var product = Context.Products.Find(id);

            return View(product);
        }

        [HttpPost]

        // Delete the Product
        public IActionResult Delete(Product product)
        {
            // Remove the desired product, save the 
            // changes to the database, and then
            // return to the prouct list (See that 
            // the product was indeed removr).
            Context.Products.Remove(product);
            Context.SaveChanges();

            return RedirectToAction("List");
        }
    }
}
