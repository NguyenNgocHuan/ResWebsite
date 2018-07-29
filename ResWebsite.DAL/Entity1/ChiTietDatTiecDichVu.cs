namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDatTiecDichVu")]
    public partial class ChiTietDatTiecDichVu
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(64)]
        public string MaHopDongDatTiec { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(64)]
        public string MaDichVu { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(256)]
        public string GhiChu { get; set; }

        public virtual DichVu DichVu { get; set; }

        public virtual HopDongDatTiec HopDongDatTiec { get; set; }
    }
}
