using System;
using System.Collections;
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

            if (id_category == "all")
            {
                var products = _context.Product.ToList();

                return Ok(products);
            }
            else
            {
                var products = _context.Product.Where(u => u.id_category.Equals(id_category));

                return Ok(products);
            }
        }

        
        // GET: api/Product/id_product
        [HttpGet("{id_product}")]
        public ActionResult<Product> GetProductDetail(string id_product)
        {

            var product = _context.Product.SingleOrDefault(u => u.id_product.Equals(id_product));

            return Ok(product);

        }

        // GET: api/Product/pagination
        [HttpGet]
        [Route("pagination")]
        public ActionResult<Product> GetPagination()
        {
            // Lấy page từ query
            var page = int.Parse(HttpContext.Request.Query["page"]);

            // Lấy số lượng từ query
            var numberProduct = int.Parse(HttpContext.Request.Query["count"]);

            // Lấy keyword của search từ query
            var keyWordSearch = HttpContext.Request.Query["search"];

            // Lấy category từ query
            var category = HttpContext.Request.Query["category"];

            //Lấy sản phẩm đầu và sẩn phẩm cuối
            var start = (page - 1) * numberProduct;
            var end = numberProduct;

            if (category == "all") // Nếu là tất cả sản phẩm
            {
                var products = _context.Product.ToList(); // Lấy tất cả sản phẩm

                var slice_products = products.Skip(start).Take(end); // Cắt sản phẩm theo trang

                if (keyWordSearch == "") // Nếu Search == ""
                {
                    return Ok(slice_products);
                }
                else // Ngược lại thì trả lại data có keyword giống với cái name_product
                {
                    var newData = slice_products.Where(value => value.name_product.ToUpper().Contains(keyWordSearch.ToString().ToUpper()));

                    return Ok(newData);
                }
            }
            else
            {
                var products = _context.Product.Where(value => value.id_category.Equals(category)); // Lấy tất cả sản phẩm

                var slice_products = products.Skip(start).Take(end); // Cắt sản phẩm theo trang

                if (keyWordSearch == "") // Nếu Search == ""
                {
                    return Ok(slice_products);
                }
                else // Ngược lại thì trả lại data có keyword giống với cái name_product
                {
                    var newData = slice_products.Where(value => value.name_product.Contains(keyWordSearch));

                    return Ok(newData);
                }
            }
        }

        [HttpGet]
        [Route("scroll")]
        public ActionResult<Product> GetScroll()
        {
            var page = HttpContext.Request.Query["page"];

            var count = HttpContext.Request.Query["count"];

            var search = HttpContext.Request.Query["search"];

            var start = (Convert.ToInt32(page) - 1) * Convert.ToInt32(count);

            var end = Convert.ToInt32(count);

            // Tìm kiếm list sản phẩm có giống với keyword search
            var products = _context.Product.Where(value => value.name_product.ToUpper().Contains(search.ToString().ToUpper()));

            var slice_product = products.Skip(start).Take(end);

            return Ok(slice_product);
        }

    }
}
