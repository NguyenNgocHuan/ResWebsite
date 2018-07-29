namespace ResWebsite.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SaleContractDetail")]
    public partial class SaleContractDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SaleContractId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemId { get; set; }

        [Column(TypeName = "money")]
        public decimal? Total { get; set; }

        [StringLength(256)]
        public string Note { get; set; }

        public virtual Item Item { get; set; }

        public virtual SaleContract SaleContract { get; set; }
    }
}
