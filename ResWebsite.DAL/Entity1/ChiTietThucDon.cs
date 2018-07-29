namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietThucDon")]
    public partial class ChiTietThucDon
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(64)]
        public string MaThucDon { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(64)]
        public string MaMonAnThucUong { get; set; }

        [StringLength(256)]
        public string GhiChu { get; set; }

        public virtual MonAnThucUong MonAnThucUong { get; set; }

        public virtual ThucDon ThucDon { get; set; }
    }
}
