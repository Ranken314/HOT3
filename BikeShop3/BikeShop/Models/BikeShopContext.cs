using Microsoft.EntityFrameworkCore;

namespace BikeShop.Models
{
    // Add Seed Data in Here
    public class BikeShopContext : DbContext
    {
        // Constructor

        public BikeShopContext(DbContextOptions<BikeShopContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Wheels" },
                new Category { CategoryID = 2, CategoryName = "Bikes" },
                new Category { CategoryID = 3, CategoryName = "Clothing" },
                new Category { CategoryID = 4, CategoryName = "Components" },
                new Category { CategoryID = 5, CategoryName = "Car Rack" },
                new Category { CategoryID = 6, CategoryName = "Accessories" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductID = 1,
                    ProductName = "AeroFlo ATB Wheels",
                    ProductDescShort = "",
                    ProductDescLong = "",
                    ProductImage = "",
                    ProductPrice = (decimal)189,
                    ProductQty = 40,
                    CategoryID = 1
                },

                new Product
                {
                    ProductID = 2,
                    ProductName = "Clear Shade 85-T Glasses",
                    ProductDescShort = "",
                    ProductDescLong = "",
                    ProductImage = "",
                    ProductPrice = (decimal)45,
                    ProductQty = 14,
                    CategoryID = 6
                },

                new Product
                {
                    ProductID = 3,
                    ProductName = "Cosmic Elite Road Warrior Wheels",
                    ProductDescShort = "",
                    ProductDescLong = "",
                    ProductImage = "",
                    ProductPrice = (decimal)165,
                    ProductQty = 22,
                    CategoryID = 1
                },

                new Product
                {
                    ProductID = 4,
                    ProductName = "Cycle-Doc Pro Repair Stands",
                    ProductDescShort = "",
                    ProductDescLong = "",
                    ProductImage = "",
                    ProductPrice = (decimal)166,
                    ProductQty = 12,
                    CategoryID = 4
                },

                new Product
                {
                    ProductID = 5,
                    ProductName = "Dog Ear Aero-Flow Floor Pumps",
                    ProductDescShort = "",
                    ProductDescLong = "",
                    ProductImage = "",
                    ProductPrice = (decimal)5,
                    ProductQty = 25,
                    CategoryID = 6
                }
                );
        }
    }
}
