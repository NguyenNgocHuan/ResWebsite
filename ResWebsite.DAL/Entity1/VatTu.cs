namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VatTu")]
    public partial class VatTu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VatTu()
        {
            ChiTietHoaDonNhapKhoes = new HashSet<ChiTietHoaDonNhapKho>();
            ChiTietHoaDonXuatKhoes = new HashSet<ChiTietHoaDonXuatKho>();
        }

        [Key]
        [StringLength(64)]
        public string MaVatTu { get; set; }

        [Required]
        [StringLength(64)]
        public string MaNhaCungCap { get; set; }

        [Required]
        [StringLength(256)]
        public string TenVatTu { get; set; }

        public long SoLuong { get; set; }

        [Required]
        [StringLength(64)]
        public string DonVi { get; set; }

        [Column(TypeName = "money")]
        public decimal DonGia { get; set; }

        public DateTime NgayHetHan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDonNhapKho> ChiTietHoaDonNhapKhoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDonXuatKho> ChiTietHoaDonXuatKhoes { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}
