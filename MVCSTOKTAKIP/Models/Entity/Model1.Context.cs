﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBMVCSTOKEntities : DbContext
    {
        public DBMVCSTOKEntities()
            : base("name=DBMVCSTOKEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBL_Departman> TBL_Departman { get; set; }
        public virtual DbSet<TBL_Kategori> TBL_Kategori { get; set; }
        public virtual DbSet<TBL_Marka> TBL_Marka { get; set; }
        public virtual DbSet<TBL_Musteri> TBL_Musteri { get; set; }
        public virtual DbSet<TBL_Personel> TBL_Personel { get; set; }
        public virtual DbSet<TBL_Satis> TBL_Satis { get; set; }
        public virtual DbSet<TBL_Urunler> TBL_Urunler { get; set; }
        public virtual DbSet<TBL_Admin> TBL_Admin { get; set; }
    }
}
