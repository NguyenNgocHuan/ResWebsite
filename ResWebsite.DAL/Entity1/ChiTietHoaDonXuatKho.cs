namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDonXuatKho")]
    public partial class ChiTietHoaDonXuatKho
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(64)]
        public string MaHoaDonXuatKho { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(64)]
        public string MaVatTu { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(256)]
        public string GhiChu { get; set; }

        public virtual HoaDonXuatKho HoaDonXuatKho { get; set; }

        public virtual VatTu VatTu { get; set; }
    }
}
