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
    
    public partial class PostCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PostCategory()
        {
            this.Posts = new HashSet<Post>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescripttion { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool Status { get; set; }
        public bool HomeFlag { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
