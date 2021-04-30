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
    public class UserController : ControllerBase
    {

        private readonly APIContext _context;

        public UserController(APIContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            var users = await _context.Users.ToListAsync();

            return Ok(users);
        }


        // GET: api/User/id_user
        [HttpGet("{id_user}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUser(string id_user)
        {
            var user = await _context.Users.SingleOrDefaultAsync(value => value.id_user.Equals(id_user));

            return Ok(user);
        }


        // GET api/User/detail?username&password
        [HttpGet]
        [Route("detail")]
        public async Task<ActionResult<User>> GetDetailUser()
        {

            var username = HttpContext.Request.Query["username"];

            var password = HttpContext.Request.Query["password"];

            var user = await _context.Users.SingleOrDefaultAsync(u => u.username.Equals(username));

            if (user == null)
            {
                return Ok("Khong Tìm Thấy User");
            }
            else
            {
                if (user.password.Equals(password))
                {
                    return Ok(user);
                }
                else
                {
                    return Ok("Sai Mat Khau");
                }
            }


        }


        // POST api/User
        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("Thanh Cong");

        }
        
    }
}
