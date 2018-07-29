namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDonNhapKho")]
    public partial class HoaDonNhapKho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDonNhapKho()
        {
            ChiTietHoaDonNhapKhoes = new HashSet<ChiTietHoaDonNhapKho>();
        }

        [Key]
        [StringLength(64)]
        public string MaHoaDonNhapKho { get; set; }

        [Required]
        [StringLength(256)]
        public string TenHoaDon { get; set; }

        [Required]
        [StringLength(64)]
        public string MaNhanVien { get; set; }

        [Required]
        [StringLength(64)]
        public string MaNhaCungCap { get; set; }

        public DateTime NgayTaoHoaDon { get; set; }

        [Column(TypeName = "money")]
        public decimal TongTien { get; set; }

        [Required]
        [StringLength(64)]
        public string TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDonNhapKho> ChiTietHoaDonNhapKhoes { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
