using BikeShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers
{
    public class ProductController : Controller
    {
        // Declare private context variable
        private BikeShopContext context { get; set; }

        // Constructor
        public ProductController(BikeShopContext ctx)
        {
            this.context = ctx;
        }

        //List all Product
        public IActionResult List()
        {
            List<Product> products = context.Products
                                            .Include(c => c.Category)
                                            .OrderBy(p => p.ProductName)
                                            .ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Category = context.Categories
                                      .OrderBy(c => c.CategoryName)
                                      .ToList();

            return View("AddEdit", new Product());
        }
        [HttpGet]

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            // Find the desired product to update
            var product = context.Products.Find(id);

            //  "Fill Up" the fields
            ViewBag.Category = context.Categories
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
                    context.Products.Add(product);
                }
                else
                {
                    // Otherwise, this is an Update.
                    context.Products.Update(product);
                }

                // Regargless of whether this is an Add or an Update,
                // save the changes to the database and then
                // return to the product list ( can see changes).
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                // Problem with the model validation
                ViewBag.Action = (product.ProductID == 0) ? "Add" : "Edit";

                ViewBag.Category = context.Categories
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
            var product = context.Products.Find(id);

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
            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("List");
        }
    }
}
