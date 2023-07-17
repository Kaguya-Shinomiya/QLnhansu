namespace QLnhansu.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Nhan_Vien
    {
        [Key]
        [StringLength(6)]
        public string MaNV { get; set; }

        [StringLength(20)]
        public string TenNV { get; set; }

        public DateTime? Ngaysinh { get; set; }

        [Required]
        [StringLength(2)]
        public string MaPB { get; set; }
    }
}
