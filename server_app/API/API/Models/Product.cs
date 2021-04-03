using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id_product")]
        public string id_product { get; set; }

        [Column("id_category")]
        public string id_category { get; set; }

        [Column("name_product")]
        public string name_product { get; set; }

        [Column("price_product")]
        public string price_product { get; set; }

        [Column("image")]
        public string image { get; set; }

        [Column("describe")]
        public string describe { get; set; }
    }
}
