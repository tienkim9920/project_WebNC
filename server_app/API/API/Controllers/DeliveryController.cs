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

        [HttpGet("{id_note}")]
        public ActionResult<Delivery> Get_Delivery(string id_note)
        {

            var delivery = _context.Delivery.SingleOrDefault(value => value.id_note.Equals(id_note));

            return Ok(delivery);

        }

    }
}
