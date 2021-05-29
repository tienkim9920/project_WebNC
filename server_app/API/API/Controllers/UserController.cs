using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;

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
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var users = await _context.Users.SingleOrDefaultAsync(u => u.username.Equals(user.username) || u.email.Equals(user.email));
            if (users != null)
            {
                return Ok("Username hoặc Email đã tồn tại");
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("Thanh Cong");
        }

        [HttpPut]
        public async Task<ActionResult<User>> ChangeProfile()
        {
            var id = HttpContext.Request.Query["id_user"];

            var fullname = HttpContext.Request.Query["fullname"];

            var updateItem = _context.Users.Find(id);

            updateItem.fullname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(fullname.ToString().Trim().ToLower());

            _context.SaveChanges();

            return Ok("Update thành công!");
        }

        [HttpPut]
        [Route("changepassword")]
        public async Task<ActionResult<User>> ChangePassword()
        {
            var password = HttpContext.Request.Query["password"];
            var newPassword = HttpContext.Request.Query["newPassword"];
            var id = HttpContext.Request.Query["id_user"];

            var users = await _context.Users.SingleOrDefaultAsync(u => u.id_user.Equals(id) && u.password.Equals(password));

            if (users == null)
            {
                return Ok("Mật khẩu sai");
            }
            else
            {
                users.password = newPassword;
                _context.SaveChanges();

                return Ok("Update thành công!");
            }
        }

        [HttpPut]
        [Route("forget")]
        public async Task<ActionResult<User>> Forget()
        {
            var email = HttpContext.Request.Query["email"];
            var password = HttpContext.Request.Query["password"];
            var newPassword = HttpContext.Request.Query["newPassword"];

            var users = await _context.Users.SingleOrDefaultAsync(u => u.email.Equals(email));

            users.password = newPassword;
            _context.SaveChanges();

            return Ok("Update thành công!");
        }


        [HttpGet]
        [Route("otp")]
        public async Task<ActionResult<User>> Post_OTP()
        {
            var email = HttpContext.Request.Query["email"];
            var users = await _context.Users.SingleOrDefaultAsync(u => u.email.Equals(email));

            if (users == null)
            {
                return Ok("Email không tồn tại");
            }

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Cửa hàng đồ ăn Jollibee", "ninhhieu112000@gmail.com"));
            message.To.Add(new MailboxAddress("Customer", email));
            message.Subject = "Mã OTP";


            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<h1> Mã OTP của quý khách là: " + HttpContext.Request.Query["otp"] + "</h1>";

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("ninhhieu112000@gmail.com", "hieusuper20hcm");

                client.Send(message);
                client.Disconnect(true);
            }


            return Ok("Vui lòng kiểm tra mail");
        }

    }
}
