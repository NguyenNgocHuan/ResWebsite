namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuyenHan")]
    public partial class QuyenHan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuyenHan()
        {
            PhanQuyens = new HashSet<PhanQuyen>();
        }

        [Key]
        [StringLength(64)]
        public string MaQuyenHan { get; set; }

        [Required]
        [StringLength(256)]
        public string TenQuyenHan { get; set; }

        [StringLength(256)]
        public string MoTa { get; set; }

        [Required]
        [StringLength(64)]
        public string MaNghiepVu { get; set; }

        public virtual NghiepVu NghiepVu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanQuyen> PhanQuyens { get; set; }
    }
}
