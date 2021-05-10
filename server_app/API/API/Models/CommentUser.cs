using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class CommentUser
    {
        public virtual Comment GetComment { get; set; }
        public virtual User GetUser { get; set; }
    }
}
