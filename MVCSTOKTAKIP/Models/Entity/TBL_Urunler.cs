//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCSTOKTAKIP.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_Urunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_Urunler()
        {
            this.TBL_Satis = new HashSet<TBL_Satis>();
        }
    
        public int UrunID { get; set; }
        public string UrunAD { get; set; }
        public Nullable<int> MARKA { get; set; }
        public string STOK { get; set; }
        public Nullable<decimal> ALISF { get; set; }
        public Nullable<decimal> SATISF { get; set; }
        public Nullable<int> KATEGORI { get; set; }
        public Nullable<bool> DURUM { get; set; }
    
        public virtual TBL_Kategori TBL_Kategori { get; set; }
        public virtual TBL_Marka TBL_Marka { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_Satis> TBL_Satis { get; set; }
    }
}