namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            ChamCongs = new HashSet<ChamCong>();
            ChiaCaLamViecs = new HashSet<ChiaCaLamViec>();
            HoaDonGoiMons = new HashSet<HoaDonGoiMon>();
            HoaDonNhapKhoes = new HashSet<HoaDonNhapKho>();
            HoaDonXuatKhoes = new HashSet<HoaDonXuatKho>();
            HopDongDatTiecs = new HashSet<HopDongDatTiec>();
            Luongs = new HashSet<Luong>();
            PhanQuyens = new HashSet<PhanQuyen>();
        }

        [Key]
        [StringLength(64)]
        public string MaNhanVien { get; set; }

        [Required]
        [StringLength(256)]
        public string TenNhanVien { get; set; }

        public bool GioiTinh { get; set; }

        public DateTime NgaySinh { get; set; }

        [Required]
        [StringLength(256)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(64)]
        public string SoDienThoai { get; set; }

        [StringLength(256)]
        public string HinhAnh { get; set; }

        [Required]
        [StringLength(64)]
        public string ChucVu { get; set; }

        public byte TrangThai { get; set; }

        [Required]
        [StringLength(64)]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(64)]
        public string MatKhau { get; set; }

        [StringLength(64)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChamCong> ChamCongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiaCaLamViec> ChiaCaLamViecs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonGoiMon> HoaDonGoiMons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonNhapKho> HoaDonNhapKhoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonXuatKho> HoaDonXuatKhoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HopDongDatTiec> HopDongDatTiecs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Luong> Luongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanQuyen> PhanQuyens { get; set; }
    }
}
