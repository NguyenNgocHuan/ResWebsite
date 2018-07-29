namespace ResWebsite.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shift")]
    public partial class Shift
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shift()
        {
            GrantShifts = new HashSet<GrantShift>();
            TimeKeepings = new HashSet<TimeKeeping>();
        }

        public int ShiftId { get; set; }

        [Required]
        [StringLength(64)]
        public string ShiftName { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        public TimeSpan? FinishTime { get; set; }

        public TimeSpan? StartTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrantShift> GrantShifts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TimeKeeping> TimeKeepings { get; set; }
    }
}
