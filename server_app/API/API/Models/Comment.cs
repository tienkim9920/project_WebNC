using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id_comment")]
        public string id_comment { get; set; }

        [Column("id_product")]
        public string id_product { get; set; }

        [Column("id_user")]
        public string id_user { get; set; }

        [Column("fullname")]
        public string fullname { get; set; }

        [Column("comment")]
        public string comment { get; set; }

        [Column("star1")]
        public string star1 { get; set; }

        [Column("star2")]
        public string star2 { get; set; }

        [Column("star3")]
        public string star3 { get; set; }

        [Column("star4")]
        public string star4 { get; set; }

        [Column("star5")]
        public string star5 { get; set; }
    }
}
