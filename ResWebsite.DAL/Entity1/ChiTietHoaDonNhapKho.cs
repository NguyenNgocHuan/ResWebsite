namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDonNhapKho")]
    public partial class ChiTietHoaDonNhapKho
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(64)]
        public string MaHoaDonNhapKho { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(64)]
        public string MaVatTu { get; set; }

        [StringLength(256)]
        public string GhiChu { get; set; }

        public int? SoLuong { get; set; }

        public virtual HoaDonNhapKho HoaDonNhapKho { get; set; }

        public virtual VatTu VatTu { get; set; }
    }
}
