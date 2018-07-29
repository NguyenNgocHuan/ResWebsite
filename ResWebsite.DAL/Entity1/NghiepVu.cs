namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NghiepVu")]
    public partial class NghiepVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NghiepVu()
        {
            QuyenHans = new HashSet<QuyenHan>();
        }

        [Key]
        [StringLength(64)]
        public string MaNghiepVu { get; set; }

        [Required]
        [StringLength(256)]
        public string TenNghiepVu { get; set; }

        [StringLength(256)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuyenHan> QuyenHans { get; set; }
    }
}
