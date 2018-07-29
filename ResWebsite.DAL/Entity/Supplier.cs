namespace ResWebsite.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            SaleContracts = new HashSet<SaleContract>();
        }

        public int SupplierId { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        public string Address { get; set; }

        [StringLength(64)]
        public string Phone { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        public int SupplierTypeId { get; set; }

        public byte? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleContract> SaleContracts { get; set; }

        public virtual SupplierType SupplierType { get; set; }
    }
}
