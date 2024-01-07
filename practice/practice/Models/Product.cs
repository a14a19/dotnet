using System;
namespace practice.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}

