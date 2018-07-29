namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChamCong")]
    public partial class ChamCong
    {
        [Key]
        [StringLength(64)]
        public string MaChamCong { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngay { get; set; }

        [Required]
        [StringLength(64)]
        public string CaLamViec { get; set; }

        public TimeSpan ThoiGianVao { get; set; }

        public TimeSpan ThoiGianRa { get; set; }

        [Required]
        [StringLength(64)]
        public string MaNhanVien { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
