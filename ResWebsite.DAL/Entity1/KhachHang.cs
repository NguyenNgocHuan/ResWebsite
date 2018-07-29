namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            BinhLuans = new HashSet<BinhLuan>();
            HopDongDatTiecs = new HashSet<HopDongDatTiec>();
        }

        [Key]
        [StringLength(64)]
        public string MaKhachHang { get; set; }

        [Required]
        [StringLength(256)]
        public string TenKhachHang { get; set; }

        [Required]
        [StringLength(64)]
        public string SoDienThoai { get; set; }

        [StringLength(64)]
        public string Email { get; set; }

        [StringLength(64)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(64)]
        public string TrangThai { get; set; }

        [Required]
        [StringLength(256)]
        public string DiaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HopDongDatTiec> HopDongDatTiecs { get; set; }
    }
}
