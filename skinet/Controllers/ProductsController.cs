using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Entities;

namespace skinet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(StoreContext context) : ControllerBase
    {
        private readonly StoreContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id) ?? new Product();
        }
    }
}