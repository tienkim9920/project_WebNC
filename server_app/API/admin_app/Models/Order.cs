//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace admin_app.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.Detail_Order = new HashSet<Detail_Order>();
        }
    
        public string id_history { get; set; }
        public string address { get; set; }
        public string total { get; set; }
        public string status { get; set; }
        public bool pay { get; set; }
        public int feeship { get; set; }
        public string id_user { get; set; }
        public string id_payment { get; set; }
        public string id_note { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detail_Order> Detail_Order { get; set; }
        public virtual Note Note { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual User User { get; set; }
    }
}
