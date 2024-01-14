using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _27_KhuatThiMinhAnh_BusinessObjects.Models;
using _27_KhuatThiMinhAnh_Repositories.Interfaces;
using _27_KhuatThiMinhAnh_Repositories.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_KhuatThiMinhAnh_Asignment01.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository repository = new ProductRepository();

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts() => repository.GetProducts();
        [HttpGet("Categories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories() => repository.GetCategories();

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = repository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.ProductID)
            {
                return BadRequest();
            }

            try
            {
                repository.UpdateProduct(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPut("Search/{minPrice}/{maxPrice}")]
        public async Task<ActionResult<IEnumerable<Product>>> SearchProduct(decimal minPrice, decimal maxPrice, [FromBody] string name)
        {
            var products = repository.SearchProduct(name, minPrice, maxPrice);
            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Create")]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            repository.AddProduct(product);

            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = repository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            repository.DeleteProduct(product);

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return repository.GetProductById(id) != null;
        }
    }
}
