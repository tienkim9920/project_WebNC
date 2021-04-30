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
    public class DeliveryController : ControllerBase
    {
        private readonly APIContext _context;

        public DeliveryController(APIContext context)
        {
            _context = context;
        }

        // POST: api/Delivery
        [HttpPost]
        public ActionResult<Delivery> Post_Delivery(Delivery data)
        {
            _context.Delivery.Add(data);
            _context.SaveChanges();

            return Ok("Thanh Cong");
        }
    }
}
