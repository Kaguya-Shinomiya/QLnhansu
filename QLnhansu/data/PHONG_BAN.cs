namespace QLnhansu.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PHONG_BAN
    {
        [Key]
        [StringLength(2)]
        public string MaPB { get; set; }

        [StringLength(30)]
        public string TenPB { get; set; }
    }
}
