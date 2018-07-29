namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDatTiecMonAnThucUong")]
    public partial class ChiTietDatTiecMonAnThucUong
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(64)]
        public string MaHopDongDatTiec { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(64)]
        public string MaMonAnThucUong { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(256)]
        public string GhiChu { get; set; }

        public virtual HopDongDatTiec HopDongDatTiec { get; set; }

        public virtual MonAnThucUong MonAnThucUong { get; set; }
    }
}
