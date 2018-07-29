namespace ResWebsite.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee_Activity_Log
    {
        [Key]
        public int ActivityLogId { get; set; }

        public int EmployeeId { get; set; }

        [StringLength(64)]
        public string Action { get; set; }

        [StringLength(64)]
        public string Method { get; set; }

        [StringLength(256)]
        public string Information { get; set; }

        public DateTime? Time { get; set; }

        [StringLength(64)]
        public string IpAddress { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
