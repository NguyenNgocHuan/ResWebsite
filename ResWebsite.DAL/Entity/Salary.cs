namespace ResWebsite.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Salary")]
    public partial class Salary
    {
        public int SalaryId { get; set; }

        public int EmployeeId { get; set; }

        [Column(TypeName = "money")]
        public decimal? BasicSalary { get; set; }

        [Column(TypeName = "money")]
        public decimal? Bonus { get; set; }

        [Column(TypeName = "money")]
        public decimal? Subsidy { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
