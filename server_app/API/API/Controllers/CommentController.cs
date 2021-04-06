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
    public class CommentController : ControllerBase
    {

        private readonly APIContext _context;

        // GET: api/Comment/id_product
        [HttpGet("{id}")]
        public ActionResult<Comment> GetComment(int id)
        {

            var comments = _context.Comments.Where(value => value.id_product.Equals(id));

            return Ok(comments);

        }

        
        [HttpPost]
        public ActionResult<Comment> PostComment()
        {
            return Ok("123");
        }

    }
}
