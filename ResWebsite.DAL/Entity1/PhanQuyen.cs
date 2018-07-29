namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanQuyen")]
    public partial class PhanQuyen
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(64)]
        public string MaQuyenHan { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(64)]
        public string MaNhanVien { get; set; }

        [StringLength(256)]
        public string GhiChu { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual QuyenHan QuyenHan { get; set; }
    }
}
