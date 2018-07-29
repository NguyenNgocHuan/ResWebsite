namespace ResWebsite.DAL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CaLamViec")]
    public partial class CaLamViec
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CaLamViec()
        {
            ChiaCaLamViecs = new HashSet<ChiaCaLamViec>();
        }

        [Key]
        [StringLength(64)]
        public string MaCaLamViec { get; set; }

        [Required]
        [StringLength(64)]
        public string TenCaLamViec { get; set; }

        public TimeSpan? ThoiGianVao { get; set; }

        public TimeSpan? ThoiGianRa { get; set; }

        [StringLength(256)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiaCaLamViec> ChiaCaLamViecs { get; set; }
    }
}
