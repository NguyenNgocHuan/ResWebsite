namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietGoiMonDichVu")]
    public partial class ChiTietGoiMonDichVu
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(64)]
        public string MaHoaDonGoiMon { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(64)]
        public string MaDichVu { get; set; }

        [StringLength(256)]
        public string GhiChu { get; set; }

        public int? SoLuong { get; set; }

        public virtual DichVu DichVu { get; set; }

        public virtual HoaDonGoiMon HoaDonGoiMon { get; set; }
    }
}
