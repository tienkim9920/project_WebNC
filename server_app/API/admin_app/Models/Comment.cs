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
    
    public partial class Comment
    {
        public string id_comment { get; set; }
        public string id_product { get; set; }
        public string comment1 { get; set; }
        public int star { get; set; }
        public string id_user { get; set; }
        public string fullname { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
