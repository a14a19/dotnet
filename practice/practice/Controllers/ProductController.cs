using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practice.Data;
using practice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace practice.Controllers
{
    [Route("api/productController")]
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext _dbContext;

        public ProductController(ApplicationDbContext dbContext) {

            _dbContext = dbContext;


        }
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    var products = _dbContext.Products.ToList();
        //    return View(products);
        //}


        [HttpGet("get-products")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var List = await _dbContext.Products.Select(
                s => new Product
                {
                    ProductId = s.ProductId,
                    ProductName = s.ProductName,
                    Cost = s.Cost,
                    Description = s.Description,
                    IsActive = s.IsActive,
                    ProductCategories = s.ProductCategories
                }
            ).ToListAsync();

                return List;
        }

        /*public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return _dbContext.Products.ToList();
        }*/

        /*public IActionResult Create()
        {
            return View();
        }*/

        [HttpPost("create-product")]
        public async Task<ActionResult<string>> CreateProduct([FromBody] Product product)
        {
            try
            {
                var entity = new Product
                {
                    //ProductId = product.ProductId, // Uncomment this line if needed
                    ProductName = product.ProductName,
                    Cost = product.Cost,
                    Description = product.Description,
                    IsActive = product.IsActive,
                    ProductCategories = product.ProductCategories
                };

                _dbContext.Products.Add(entity);
                await _dbContext.SaveChangesAsync();

                return Ok("Product added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding product: {ex.Message}");
            }
        }

        /*public ActionResult<Product> CreateProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetProducts), new { id = product.ProductId }, product);
        }*/




    }
}

