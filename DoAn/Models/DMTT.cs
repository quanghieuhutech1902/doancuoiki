//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAn.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DMTT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMTT()
        {
            this.TINTUC = new HashSet<TINTUC>();
        }
    
        public int ID { get; set; }
        public string TenDMTT { get; set; }
        public Nullable<System.DateTime> NgayCN { get; set; }
        public string MoTa { get; set; }
        public string TuKhoa { get; set; }
        public string TieuDeSeo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TINTUC> TINTUC { get; set; }
    }
}
