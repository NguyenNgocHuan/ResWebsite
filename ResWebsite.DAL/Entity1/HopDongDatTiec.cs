namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HopDongDatTiec")]
    public partial class HopDongDatTiec
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HopDongDatTiec()
        {
            ChiTietDatTiecDichVus = new HashSet<ChiTietDatTiecDichVu>();
            ChiTietDatTiecMonAnThucUongs = new HashSet<ChiTietDatTiecMonAnThucUong>();
        }

        [Key]
        [StringLength(64)]
        public string MaHopDongDatTiec { get; set; }

        [Required]
        [StringLength(256)]
        public string TenHopDong { get; set; }

        [Required]
        [StringLength(64)]
        public string MaNhanVien { get; set; }

        [Required]
        [StringLength(64)]
        public string MaKhachHang { get; set; }

        public DateTime NgayTaoHopDong { get; set; }

        public DateTime NgayHetHan { get; set; }

        public DateTime NgayToChuc { get; set; }

        public int SoLuongKhach { get; set; }

        [Required]
        [StringLength(64)]
        public string MaDiaDiem { get; set; }

        [Column(TypeName = "money")]
        public decimal TongTien { get; set; }

        [StringLength(64)]
        public string SoTaiKhoan { get; set; }

        [Column(TypeName = "money")]
        public decimal? SoTienTraTruoc { get; set; }

        [Required]
        [StringLength(256)]
        public string KieuThanhToan { get; set; }

        [Required]
        [StringLength(64)]
        public string TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatTiecDichVu> ChiTietDatTiecDichVus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatTiecMonAnThucUong> ChiTietDatTiecMonAnThucUongs { get; set; }

        public virtual DiaDiem DiaDiem { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
