using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeShop.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "The product name is required.")]
        public string ProductName { get; set; } = string.Empty;

        public string? ProductDescShort { get; set; }
        public string? ProductDescLong { get; set; }
        public string? ProductImage { get; set; }

        [Required(ErrorMessage = "The product price is required.")]
        [Range(1, 100000, ErrorMessage = "The product price must be between 1 and 100,000.")]
        [Column(TypeName = "decimal (8, 2)")]
        public decimal ProductPrice { get; set; }

        [Required(ErrorMessage = "The product quantity is required.")]
        [Range(1, 100000, ErrorMessage = "The product quantity must be between 1 and 100,000.")]
        public int ProductQty { get; set; }

        [Required(ErrorMessage = "The category is required.")]
        public int CategoryID { get; set; }

        // Navigation property
        [ValidateNever]
        public Category? Category { get; set; }

        public string Slug => ProductName?.Replace(' ', '-').ToLower() + '/' ?? string.Empty;
    }
}
