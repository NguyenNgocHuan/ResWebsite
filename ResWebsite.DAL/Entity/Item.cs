namespace ResWebsite.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            ExportImportDetails = new HashSet<ExportImportDetail>();
            SaleContractDetails = new HashSet<SaleContractDetail>();
        }

        public int ItemId { get; set; }

        public int WarehouseTypeId { get; set; }

        [Required]
        [StringLength(256)]
        public string ItemName { get; set; }

        public long Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public int? UnitId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExportImportDetail> ExportImportDetails { get; set; }

        public virtual Unit Unit { get; set; }

        public virtual WarehouseType WarehouseType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleContractDetail> SaleContractDetails { get; set; }
    }
}
