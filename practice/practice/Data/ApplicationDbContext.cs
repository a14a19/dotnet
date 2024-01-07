//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using practice.Models;

//namespace practice.Data;

//public class ApplicationDbContext : IdentityDbContext
//{
//    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//        : base(options)
//    {
//    }
//    public DbSet<Product> Products { get; set; }
//    public DbSet<ProductCategory> ProductCategories { get; set; }
//}


using Microsoft.EntityFrameworkCore;
using practice.Models;

namespace practice.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);

            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => pc.CategoryId);

            // Configure the one-to-many relationship
            // modelBuilder.Entity<Product>()
            //     .HasMany(p => p.ProductCategories)
            //     .WithOne(pc => pc.Product)
            //     .HasForeignKey(pc => pc.CategoryId);
            // modelBuilder.Entity<Product>()
            // .HasMany(p => p.ProductCategories)
            // .WithOne()
            // .HasForeignKey(r => r.CategoryId);
        }

    }
}

