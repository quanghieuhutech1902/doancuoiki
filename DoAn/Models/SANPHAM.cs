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
    
    public partial class SANPHAM
    {
        public int ID { get; set; }
        public string TenSP { get; set; }
        public string SoLuong { get; set; }
        public Nullable<bool> TinhTrang { get; set; }
        public string HinhAnh { get; set; }
        public string Mota { get; set; }
        public string NoiDung { get; set; }
        public Nullable<int> Gia { get; set; }
        public string GiaKM { get; set; }
        public Nullable<int> DMSP_ID { get; set; }
        public string TieuDeSeo { get; set; }
        public Nullable<int> Moi { get; set; }
    
        public virtual DMSP DMSP { get; set; }
    }
}
