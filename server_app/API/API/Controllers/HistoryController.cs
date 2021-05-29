using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly APIContext _context;

        public HistoryController(APIContext context)
        {
            _context = context;
        }

        // GET: api/History
        [HttpGet]
        public ActionResult<History> GetHistory()
        {
            var id_user = HttpContext.Request.Query["id_user"];

            var history = _context.History.Where(value => value.id_user.Equals(id_user));

            return Ok(history);
        }

        // GET: api/History/id_history
        [HttpGet("{id_history}")]
        public ActionResult<History> GetDetailHistory(string id_history)
        {

            var history = _context.History.SingleOrDefault(value => value.id_history.Equals(id_history));

            return Ok(history);

        }

        // POST: api/History
        [HttpPost]
        public ActionResult<History> Post_History(History data)
        {
            _context.History.Add(data);
            _context.SaveChanges();

            return Ok("Thanh Cong!");
        }


        // POST: api/History/sendmail dung de gui email
        //[HttpPost]
        //[Route("sendmail")]
        //public ActionResult Post_SendMail()
       // {
            //var id_find = HttpContext.Request.Query["id_find"];

            //var history = _context.History.SingleOrDefault(value => value.id_find.Equals(id_find));

            //var message = new MimeMessage();

            //message.From.Add(new MailboxAddress("Admin", "tienkim9920@gmail.com"));
            //message.To.Add(new MailboxAddress("Customer","minhhieu0112000@gmail.com"));
            //message.Subject = "Mã OTP";

            //var carts = _context.Carts.Where(value => value.id_user.Equals(history.id_user));

            //var delivery = _context.Delivery.SingleOrDefault(value => value.id_history.Equals(history.id_history));

            //var htmlHead = "<table style='width:50%'>" +
            //    "<tr style='border: 1px solid black;'>" +
            //    "<th style='border: 1px solid black;'>Tên Sản Phẩm</th>" +
            //    "<th style='border: 1px solid black;'>Hình Ảnh</th>" +
            //    "<th style='border: 1px solid black;'>Giá</th>" +
            //    "<th style='border: 1px solid black;'>Số Lượng</th>" +
            //    "<th style='border: 1px solid black;'>Giá Tiền</th>";

            //var htmlContent = "";

            //foreach (var value in carts)
            //{
            //    htmlContent += "<tr>" +
            //    "<td style='border: 1px solid black; font-size: 1.2rem; text-align: center;'>" + value.name_product + "</td>" +
            //    "<td style='border: 1px solid black; font-size: 1.2rem; text-align: center;'><img src='" + value.image + "' width='80' height='80'></td>" +
            //    "<td style='border: 1px solid black; font-size: 1.2rem; text-align: center;'>" + value.price_product + "$</td>" +
            //    "<td style='border: 1px solid black; font-size: 1.2rem; text-align: center;'>" + value.count + "</td>" +
            //    "<td style='border: 1px solid black; font-size: 1.2rem; text-align: center;'>" + Convert.ToInt32(value.price_product) * Convert.ToInt32(value.count) + "$</td>" +
            //    "<tr>";
            //}

            //var htmlResult = "<h1>Xin Chào " + history.fullname + "</h1>" + "<h3>Phone: " + history.phone + "</h3>" + "<h3>Address:" + history.address + "</h3>" +
            //htmlHead + htmlContent + "<h1>Phí Vận Chuyển: " + delivery.price + "$</h1></br>" + "<h1>Tổng Thanh Toán: " + history.total + "$</h1></br><p>Cảm ơn bạn!</p>";

            //BodyBuilder bodyBuilder = new BodyBuilder();
            //bodyBuilder.HtmlBody = "1515";

            //message.Body = bodyBuilder.ToMessageBody();

            //using (var client = new SmtpClient())
            //{
            //    client.Connect("smtp.gmail.com", 587, false);
            //    client.Authenticate("ninhhieu112000@gmail.com", "hieusuper20hcm");

            //    client.Send(message);
            //    client.Disconnect(true);
            //}


            //return Ok("Thanh Cong!");
        //}

    }
}
