using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Delivery")]
    public class Delivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id_delivery")]
        public string id_delivery { get; set; }

        [Column("id_history")]
        public string id_history { get; set; }

        [Column("address_from")]
        public string address_from { get; set; }

        [Column("address_to")]
        public string address_to { get; set; }

        [Column("distance")]
        public string distance { get; set; }

        [Column("duration")]
        public string duration { get; set; }

        [Column("price")]
        public string price { get; set; }
    }
}
