using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly APIContext _context;

        public ProductController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProduct()
        {

            var products = await _context.Product.ToListAsync();

            return Ok(products);

        }

        // GET: api/Product?id_category=?
        [HttpGet]
        public ActionResult<Product> GetProduct()
        {
            var id_category = HttpContext.Request.Query["id_category"];

            var products = _context.Product.Where(u => u.id_category.Equals(id_category));

            return Ok(products);
        }

        
        // GET: api/Product/id_product
        [HttpGet("{id_product}")]
        public ActionResult<Product> GetProductDetail(string id_product)
        {

            var product = _context.Product.SingleOrDefault(u => u.id_product.Equals(id_product));

            return Ok(product);

        }

    }
}
