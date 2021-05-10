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
    public class CommentController : ControllerBase
    {

        private readonly APIContext _context;

        public CommentController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Comment/id_product
        [HttpGet("{id_product}")]
        public ActionResult<Comment> GetComment(string id_product)
        {

            var comments = _context.Comments.Where(value => value.id_product.Equals(id_product)).ToList();

            return Ok(comments);

        }

        [HttpPost]
        public ActionResult<Comment> PostComment(Comment comment)
        {

            _context.Comments.Add(comment);
            _context.SaveChanges();

            return Ok("Thanh Cong");
        }

    }
}
