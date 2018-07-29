namespace ResWebsite.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SaleContract")]
    public partial class SaleContract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SaleContract()
        {
            SaleContractDetails = new HashSet<SaleContractDetail>();
        }

        public int SaleContractId { get; set; }

        [Required]
        [StringLength(256)]
        public string SaleContractName { get; set; }

        public int SupplierId { get; set; }

        public DateTime ContractDate { get; set; }

        [Required]
        [StringLength(64)]
        public string Shipper { get; set; }

        [StringLength(256)]
        public string Note { get; set; }

        public byte? Status { get; set; }

        public virtual Supplier Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleContractDetail> SaleContractDetails { get; set; }
    }
}
