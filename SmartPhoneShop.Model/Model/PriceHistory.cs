//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartPhoneShop.Model.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PriceHistory
    {
        public int ProductID { get; set; }
        public string UpdateBy { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public Nullable<double> Price { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
