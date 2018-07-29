namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDonGoiMon")]
    public partial class HoaDonGoiMon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDonGoiMon()
        {
            ChiTietGoiMonDichVus = new HashSet<ChiTietGoiMonDichVu>();
            ChiTietGoiMonMonAnThucUongs = new HashSet<ChiTietGoiMonMonAnThucUong>();
        }

        [Key]
        [StringLength(64)]
        public string MaHoaDonGoiMon { get; set; }

        [Required]
        [StringLength(256)]
        public string TenHoaDon { get; set; }

        [Required]
        [StringLength(64)]
        public string MaNhanVien { get; set; }

        [Required]
        [StringLength(64)]
        public string MaDiaDiem { get; set; }

        public DateTime NgayTaoHoaDon { get; set; }

        [Column(TypeName = "money")]
        public decimal TongTien { get; set; }

        [Required]
        [StringLength(64)]
        public string TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGoiMonDichVu> ChiTietGoiMonDichVus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGoiMonMonAnThucUong> ChiTietGoiMonMonAnThucUongs { get; set; }

        public virtual DiaDiem DiaDiem { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
