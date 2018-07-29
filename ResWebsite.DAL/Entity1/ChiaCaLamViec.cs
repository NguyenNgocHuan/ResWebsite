namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiaCaLamViec")]
    public partial class ChiaCaLamViec
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(64)]
        public string MaCalamViec { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(64)]
        public string MaNhanVien { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime Ngay { get; set; }

        [StringLength(256)]
        public string GhiChu { get; set; }

        public virtual CaLamViec CaLamViec { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
