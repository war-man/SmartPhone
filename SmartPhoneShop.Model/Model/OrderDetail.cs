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
    
    public partial class OrderDetail
    {
        public int ProductID { get; set; }
        public int OrdersID { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<bool> Shipping { get; set; }
        public Nullable<bool> Payment { get; set; }
        public Nullable<int> warranty { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
