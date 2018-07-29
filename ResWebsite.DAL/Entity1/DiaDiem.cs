namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiaDiem")]
    public partial class DiaDiem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiaDiem()
        {
            HoaDonGoiMons = new HashSet<HoaDonGoiMon>();
            HopDongDatTiecs = new HashSet<HopDongDatTiec>();
        }

        [Key]
        [StringLength(64)]
        public string MaDiaDiem { get; set; }

        [Required]
        [StringLength(256)]
        public string TenDiaDiem { get; set; }

        [StringLength(256)]
        public string HinhAnh { get; set; }

        [Required]
        [StringLength(256)]
        public string KhuVuc { get; set; }

        [Column(TypeName = "money")]
        public decimal? GiaTien { get; set; }

        public int? SoChoNgoi { get; set; }

        public int? SoChoConLai { get; set; }

        [StringLength(64)]
        public string TrangThai { get; set; }

        [StringLength(256)]
        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonGoiMon> HoaDonGoiMons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HopDongDatTiec> HopDongDatTiecs { get; set; }
    }
}
