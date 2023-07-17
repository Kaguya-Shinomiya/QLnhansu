using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLnhansu.data
{
    public partial class QLNhansu : DbContext
    {
        public QLNhansu()
            : base("name=QLNhansu")
        {
        }

        public virtual DbSet<Nhan_Vien> Nhan_Vien { get; set; }
        public virtual DbSet<PHONG_BAN> PHONG_BAN { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nhan_Vien>()
                .Property(e => e.MaNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Nhan_Vien>()
                .Property(e => e.MaPB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHONG_BAN>()
                .Property(e => e.MaPB)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
