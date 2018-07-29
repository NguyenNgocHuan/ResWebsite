namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThucDon")]
    public partial class ThucDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThucDon()
        {
            ChiTietThucDons = new HashSet<ChiTietThucDon>();
        }

        [Key]
        [StringLength(64)]
        public string MaThucDon { get; set; }

        [Required]
        [StringLength(200)]
        public string TenThucDon { get; set; }

        [Required]
        [StringLength(64)]
        public string LoaiThucDon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietThucDon> ChiTietThucDons { get; set; }
    }
}
