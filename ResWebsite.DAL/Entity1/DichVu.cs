namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DichVu")]
    public partial class DichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DichVu()
        {
            ChiTietDatTiecDichVus = new HashSet<ChiTietDatTiecDichVu>();
            ChiTietGoiMonDichVus = new HashSet<ChiTietGoiMonDichVu>();
        }

        [Key]
        [StringLength(64)]
        public string MaDichVu { get; set; }

        [Required]
        [StringLength(256)]
        public string TenDichVu { get; set; }

        [Column(TypeName = "money")]
        public decimal GiaTien { get; set; }

        [Required]
        [StringLength(256)]
        public string LoaiDichVu { get; set; }

        [Required]
        [StringLength(64)]
        public string TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatTiecDichVu> ChiTietDatTiecDichVus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGoiMonDichVu> ChiTietGoiMonDichVus { get; set; }
    }
}
