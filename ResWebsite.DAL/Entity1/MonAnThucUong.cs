namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MonAnThucUong")]
    public partial class MonAnThucUong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MonAnThucUong()
        {
            ChiTietDatTiecMonAnThucUongs = new HashSet<ChiTietDatTiecMonAnThucUong>();
            ChiTietGoiMonMonAnThucUongs = new HashSet<ChiTietGoiMonMonAnThucUong>();
            ChiTietThucDons = new HashSet<ChiTietThucDon>();
        }

        [Key]
        [StringLength(64)]
        public string MaMonAnThucUong { get; set; }

        [Required]
        [StringLength(256)]
        public string TenMonAnThucUong { get; set; }

        [Column(TypeName = "money")]
        public decimal DonGia { get; set; }

        [Required]
        [StringLength(64)]
        public string DonVi { get; set; }

        [Required]
        [StringLength(64)]
        public string PhanLoai { get; set; }

        [Required]
        [StringLength(256)]
        public string HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatTiecMonAnThucUong> ChiTietDatTiecMonAnThucUongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGoiMonMonAnThucUong> ChiTietGoiMonMonAnThucUongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietThucDon> ChiTietThucDons { get; set; }
    }
}
