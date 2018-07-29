namespace ResWebsite.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Account_Log = new HashSet<Account_Log>();
            Employee_Activity_Log = new HashSet<Employee_Activity_Log>();
            ExportImports = new HashSet<ExportImport>();
            Orders = new HashSet<Order>();
            GrantPermissions = new HashSet<GrantPermission>();
            GrantShifts = new HashSet<GrantShift>();
            Salaries = new HashSet<Salary>();
            TimeKeepings = new HashSet<TimeKeeping>();
        }

        public int EmployeeId { get; set; }

        [Required]
        [StringLength(256)]
        public string EmployeeName { get; set; }

        public bool? Gender { get; set; }

        public DateTime? BirthDay { get; set; }

        [StringLength(256)]
        public string Address { get; set; }

        [StringLength(64)]
        public string Phone { get; set; }

        [StringLength(256)]
        public string Picture { get; set; }

        public byte? IsAdmin { get; set; }

        public byte? Allowed { get; set; }

        [Required]
        [StringLength(64)]
        public string Username { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        [StringLength(64)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account_Log> Account_Log { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee_Activity_Log> Employee_Activity_Log { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExportImport> ExportImports { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrantPermission> GrantPermissions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrantShift> GrantShifts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Salary> Salaries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TimeKeeping> TimeKeepings { get; set; }
    }
}
