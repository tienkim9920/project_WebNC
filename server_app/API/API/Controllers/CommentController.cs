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

        public CommentController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Comment/id_product
        [HttpGet("{id_product}")]
        public ActionResult<Comment> GetComment(string id_product)
        {

            var comments = _context.Comments.Where(value => value.id_product.Equals(id_product));

            return Ok(comments);

        }

        
        [HttpPost]
        public ActionResult<Comment> PostComment()
        {
            var id_comment = HttpContext.Request.Query["id_comment"];

            var id_product = HttpContext.Request.Query["id_product"];

            var id_user = HttpContext.Request.Query["id_user"];

            var comment = HttpContext.Request.Query["comment"];

            var star = HttpContext.Request.Query["star"];

            // Tìm fullname của user
            var user = _context.Users.SingleOrDefault(value => value.id_user.Equals(id_user));

            string star1 = "";
            string star2 = "";
            string star3 = "";
            string star4 = "";
            string star5 = "";

            for (int i = 0; i < Convert.ToInt32(star); i++)
            {
                if (i == 0)
                {
                    star1 = "fa fa-star";
                }
                if (i == 1)
                {
                    star2 = "fa fa-star";
                }
                if (i == 2)
                {
                    star3 = "fa fa-star";
                }
                if (i == 3)
                {
                    star4 = "fa fa-star";
                }
                if (i == 4)
                {
                    star5 = "fa fa-star";
                }
            }

            Comment data_comment = new Comment();
            data_comment.id_comment = id_comment;
            data_comment.id_product = id_product;
            data_comment.id_user = id_user;
            data_comment.fullname = user.fullname;
            data_comment.comment = comment;
            data_comment.star1 = star1;
            data_comment.star2 = star2;
            data_comment.star3 = star3;
            data_comment.star4 = star4;
            data_comment.star5 = star5;

            _context.Comments.Add(data_comment);
            _context.SaveChanges();

            return Ok("Thanh Cong");
        }

    }
}
