using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly APIContext _context;

        public CartController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Cart?id_user
        [HttpGet]
        public ActionResult<Cart> GetCart()
        {
            var id_user = HttpContext.Request.Query["id_user"];

            var carts = _context.Carts.Where(value => value.id_user.Equals(id_user));

            return Ok(carts);

        }

        // POST: api/Cart
        [HttpPost]
        public ActionResult<Cart> PostCart(Cart cart)
        {

            var user_carts = _context.Carts.Where(value => value.id_user.Equals(cart.id_user));

            if (user_carts.Count() < 1)
            {
                _context.Carts.Add(cart);
                _context.SaveChanges();
            }
            else
            {
                var find_cart = _context.Carts.SingleOrDefault(value => value.id_user.Equals(cart.id_user) &&
                        value.id_product.Equals(cart.id_product));

                if (find_cart != null)
                {
                    find_cart.count = find_cart.count + Convert.ToInt32(cart.count);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Carts.Add(cart);
                    _context.SaveChanges();
                }

            }

            return Ok("Thanh Cong!");
        }

        // PUT: api/Cart?id_cart&count
        [HttpPut]
        public ActionResult<Cart> PutCart()
        {
            var id_cart = HttpContext.Request.Query["id_cart"];

            var count = HttpContext.Request.Query["count"];

            var cart = _context.Carts.SingleOrDefault(value => value.id_cart.Equals(id_cart));
            cart.count = Convert.ToInt32(count);

            _context.SaveChanges();

            return Ok("Update Thanh Cong!");
        }

        // DELETE: api/Cart/id_cart
        [HttpDelete("{id_cart}")]
        public ActionResult<Cart> DeleteCart(string id_cart)
        {
            var cart = _context.Carts.SingleOrDefault(value => value.id_cart.Equals(id_cart));

            _context.Carts.Remove(cart);
            _context.SaveChanges();

            return Ok("Thanh Cong!");
        }

    }
}
