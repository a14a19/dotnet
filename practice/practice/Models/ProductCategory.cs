using System;
namespace practice.Models
{
    public class ProductCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }

        // Navigation property back to Product
        // public Product Product { get; set; }
        // public int ProductId { get; set; }

    }
}

