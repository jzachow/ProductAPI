using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly NorthwindContext _context;

        public ProductsController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductOverview>>> GetProducts()
        {
            var allProducts = await _context.Products.ToListAsync();
            var productOverviews = new List<ProductOverview>();

            foreach (var product in allProducts)
            {
                var overview = new ProductOverview()
                {
                    Id = product.ProductId,
                    Name = product.ProductName
                };
                productOverviews.Add(overview);
            }
            return productOverviews;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            return product;
        }

        [HttpGet("ByCategory/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Products>>> GetProductsByCategory(int categoryId)
        {
            var products = await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();

            if (products == null)
                return NotFound();

            return products;
        }

        [HttpGet("BySupplier/{supplierId}")]
        public async Task<ActionResult<IEnumerable<Products>>> GetProductsBySupplier(int supplierId)
        {
            var products = await _context.Products.Where(p => p.SupplierId == supplierId).ToListAsync();

            if (products == null)
                return NotFound();

            return products;
        }

        [HttpGet("ByPrice/{maxPrice}")]
        public async Task<ActionResult<IEnumerable<Products>>> GetProductsByMaxPrice(decimal maxPrice)
        {
            var products = await _context.Products.Where(p => p.UnitPrice <= maxPrice).ToListAsync();

            if (products == null)
                return NotFound();

            return products;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Products product)
        {
            if (id != product.ProductId)
                return BadRequest();

            _context.Update(product);
            await _context.SaveChangesAsync();
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
