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

        [Column("address")]
        public string address { get; set; }

        [Column("total")]
        public string total { get; set; }

        [Column("status")]
        public string status { get; set; }

        [Column("pay")]
        public bool pay { get; set; }

        [Column("feeship")]
        public int feeship { get; set; }

        [Column("id_user")]
        public string id_user { get; set; }

        [Column("id_payment")]
        public string id_payment { get; set; }

        [Column("id_note")]
        public string id_note { get; set; }

    }
}
