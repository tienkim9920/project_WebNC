using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Note")]
    public class Delivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id_note")]
        public string id_note { get; set; }

        [Column("fullname")]
        public string fullname { get; set; }

        [Column("phone")]
        public string phone { get; set; }

    }
}
