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
    public class DetailHistoryController : ControllerBase
    {
        private readonly APIContext _context;

        public DetailHistoryController(APIContext context)
        {
            _context = context;
        }

        // GET: api/DetailHistory/id_history
        [HttpGet("{id_history}")]
        public ActionResult<DetailHistory> Get_Detail_History(string id_history)
        {
            var detail_history = _context.DetailHistory.Where(value => value.id_history.Equals(id_history));

            return Ok(detail_history);

        }

        // POST: api/DetailHistory
        [HttpPost]
        public ActionResult<DetailHistory> Post_Detail_History(DetailHistory data)
        {

            _context.DetailHistory.Add(data);
            _context.SaveChanges();

            return Ok("Thanh Cong");
        }

    }
}
