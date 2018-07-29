namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDonXuatKho")]
    public partial class HoaDonXuatKho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDonXuatKho()
        {
            ChiTietHoaDonXuatKhoes = new HashSet<ChiTietHoaDonXuatKho>();
        }

        [Key]
        [StringLength(64)]
        public string MaHoaDonXuatKho { get; set; }

        [Required]
        [StringLength(256)]
        public string TenHoaDon { get; set; }

        [Required]
        [StringLength(64)]
        public string MaNhanVien { get; set; }

        public DateTime NgayTaoHoaDon { get; set; }

        [Column(TypeName = "money")]
        public decimal TongTien { get; set; }

        [Required]
        [StringLength(64)]
        public string TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDonXuatKho> ChiTietHoaDonXuatKhoes { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
