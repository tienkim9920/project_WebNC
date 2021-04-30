using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly APIContext _context;

        public OrderController(APIContext context)
        {
            _context = context;
        }


        IHostingEnvironment env = null;

        public OrderController(IHostingEnvironment env)
        {
            this.env = env;
        }

        // POST: api/Order/sendmail
        [HttpPost]
        [Route("sendmail")]
        public ActionResult Sendmail()
        {
            //var id_find = HttpContext.Request.Query["id_find"];

            //var history = _context.History.SingleOrDefault(value => value.id_find.Equals(id_find));

            //MimeMessage message = new MimeMessage();

            //MailboxAddress from = new MailboxAddress("Admin",
            //"tienkim9920@gmail.com");
            //message.From.Add(from);

            //MailboxAddress to = new MailboxAddress("Customer", history.email);
            //message.To.Add(to);

            //message.Subject = "Hóa Đơn Đặt Hàng";

            //var carts = _context.Carts.Where(value => value.id_user.Equals(history.id_user));

            //var delivery = _context.Delivery.SingleOrDefault(value => value.id_history.Equals(history.id_history));

            //var htmlHead = "<table style='width:50%'>" +
            //    "<tr style='border: 1px solid black;'>" +
            //    "<th style='border: 1px solid black;'>Tên Sản Phẩm</th>" +
            //    "<th style='border: 1px solid black;'>Hình Ảnh</th>" +
            //    "<th style='border: 1px solid black;'>Giá</th>" +
            //    "<th style='border: 1px solid black;'>Số Lượng</th>" +
            //    "<th style='border: 1px solid black;'>Size</th>" +
            //    "<th style='border: 1px solid black;'>Thành Tiền</th>";

            //var htmlContent = "";

            //foreach (var value in carts)
            //{
            //    htmlContent += "<tr>" +
            //    "<td style='border: 1px solid black; font-size: 1.2rem; text-align: center;'>" + value.name_product + "</td>" +
            //    "<td style='border: 1px solid black; font-size: 1.2rem; text-align: center;'><img src='" + value.image + "' width='80' height='80'></td>" +
            //    "<td style='border: 1px solid black; font-size: 1.2rem; text-align: center;'>" + value.price_product + "$</td>" +
            //    "<td style='border: 1px solid black; font-size: 1.2rem; text-align: center;'>" + value.count + "</td>" +
            //    "<td style='border: 1px solid black; font-size: 1.2rem; text-align: center;'>" + (int.Parse(value.price_product) * Convert.ToInt32(value.count)) + "$</td>" +
            //    "<tr>";
            //}

            //var htmlResult = "<h1>Xin Chào " + history.fullname + "</h1>" + "<h3>Phone: " + history.phone + "</h3>" + "<h3>Address:" + history.address + "</h3>" +
            //htmlHead + htmlContent + "<h1>Phí Vận Chuyển: " + delivery.price + "$</h1></br>" + "<h1>Tổng Thanh Toán: " + history.total + "$</h1></br><p>Cảm ơn bạn!</p>";

            //BodyBuilder bodyBuilder = new BodyBuilder();
            //bodyBuilder.HtmlBody = htmlResult;

            //bodyBuilder.Attachments.Add(env.WebRootPath + "\\file.png");

            //message.Body = bodyBuilder.ToMessageBody();

            //SmtpClient client = new SmtpClient();
            //client.Connect("smtp.gmail.com", 587, true);
            //client.Authenticate("tienkim9920@gmail.com", "Tktk0909@");

            //client.Send(message);
            //client.Disconnect(true);
            //client.Dispose();

            //foreach(var value in carts)
            //{
            //    DetailHistory detail = new DetailHistory();

            //    detail.id_detail_history = "CT" + new Random().Next(1000, 100000000);
            //    detail.id_history = history.id_history;
            //    detail.name_product = value.name_product;
            //    detail.price_product = value.price_product;
            //    detail.count = value.count.ToString();
            //    detail.image = value.image;

            //    _context.DetailHistory.Add(detail);

            //    _context.Carts.Remove(value);

            //    _context.SaveChanges();
            //}

            return Ok("Thanh Cong");

        }

    }
}
