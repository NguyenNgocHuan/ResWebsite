namespace ResWebsite.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExportImport")]
    public partial class ExportImport
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExportImport()
        {
            ExportImportDetails = new HashSet<ExportImportDetail>();
        }

        public int ExportImportId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime DateExportImport { get; set; }

        public int ExportImportTypeId { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExportImportDetail> ExportImportDetails { get; set; }

        public virtual ExportImportType ExportImportType { get; set; }
    }
}
