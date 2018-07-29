namespace ResWebsite.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReservationBill")]
    public partial class ReservationBill
    {
        public int ReservationBillId { get; set; }

        public int ReservationContractId { get; set; }

        public int? CardNumber { get; set; }

        [Column(TypeName = "money")]
        public decimal? PrePay { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalPay { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        [StringLength(256)]
        public string TypePay { get; set; }

        public virtual ReservationContract ReservationContract { get; set; }
    }
}
