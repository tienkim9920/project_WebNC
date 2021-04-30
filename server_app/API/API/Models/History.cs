using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Order")]
    public class History
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id_history")]
        public string id_history { get; set; }

        [Column("id_user")]
        public string id_user { get; set; }

        [Column("fullname")]
        public string fullname { get; set; }

        [Column("phone")]
        public string phone { get; set; }

        [Column("address")]
        public string address { get; set; }

        [Column("email")]
        public string email { get; set; }

        [Column("total")]
        public string total { get; set; }

        [Column("status")]
        public bool status { get; set; }

        [Column("delivery")]
        public int delivery { get; set; }

        [Column("id_payment")]
        public string id_payment { get; set; }

        [Column("id_find")]
        public string id_find { get; set; }
    }
}
