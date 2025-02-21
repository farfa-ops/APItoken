using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using APItoken.Models;
using Microsoft.EntityFrameworkCore;
namespace APItoken.Controllers { 
    [ApiController]
    //[Authorize]
    [Route("api/[controller]/[action]")]

    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;
        public ProductController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet("Id")]
        public async Task<ActionResult>GetById(int id)
    {
        var product = await _context.Products.FindAsync(id);
        return product == null ? NotFound() : Ok(product);
        
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await _context.Products.ToListAsync();
        }
    }
}


