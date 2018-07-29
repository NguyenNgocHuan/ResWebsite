namespace ResWebsite.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TimeKeeping")]
    public partial class TimeKeeping
    {
        public int TimeKeepingId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public TimeSpan? TimeIn { get; set; }

        public TimeSpan? TimeOut { get; set; }

        public int? Status { get; set; }

        public int EmployeeId { get; set; }

        public int ShiftId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Shift Shift { get; set; }
    }
}
