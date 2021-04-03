using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id_cart")]
        public string id_cart { get; set; }

        [Column("id_user")]
        public string id_user { get; set; }

        [Column("id_product")]
        public string id_product { get; set; }

        [Column("name_product")]
        public string name_product { get; set; }

        [Column("price_product")]
        public string price_product { get; set; }

        [Column("count")]
        public int count { get; set; }

        [Column("image")]
        public string image { get; set; }

    }
}
