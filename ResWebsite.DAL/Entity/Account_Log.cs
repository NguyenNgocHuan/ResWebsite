namespace ResWebsite.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account_Log
    {
        [Key]
        public int AccountLogId { get; set; }

        public int EmployeeId { get; set; }

        [StringLength(64)]
        public string Action { get; set; }

        public DateTime? Time { get; set; }

        [StringLength(64)]
        public string IpAddress { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
