namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaCungCap")]
    public partial class NhaCungCap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaCungCap()
        {
            HoaDonNhapKhoes = new HashSet<HoaDonNhapKho>();
            VatTus = new HashSet<VatTu>();
        }

        [Key]
        [StringLength(64)]
        public string MaNhaCungCap { get; set; }

        [Required]
        [StringLength(256)]
        public string TenNhaCungCap { get; set; }

        [Required]
        [StringLength(256)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(64)]
        public string SoDienThoai { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        [Required]
        [StringLength(256)]
        public string LoaiNhaCungCap { get; set; }

        [Required]
        [StringLength(64)]
        public string TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonNhapKho> HoaDonNhapKhoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VatTu> VatTus { get; set; }
    }
}
