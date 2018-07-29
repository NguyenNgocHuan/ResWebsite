namespace ResWebsite.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReservationContract")]
    public partial class ReservationContract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReservationContract()
        {
            ReservationBills = new HashSet<ReservationBill>();
            ReservationMealDrinkDetails = new HashSet<ReservationMealDrinkDetail>();
            ReservationServiceDetails = new HashSet<ReservationServiceDetail>();
        }

        public int ReservationContractId { get; set; }

        [Required]
        [StringLength(256)]
        public string ReservationContractName { get; set; }

        public int CustomerId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public DateTime EffectDate { get; set; }

        public int PlaceId { get; set; }

        [StringLength(64)]
        public string Status { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        public int? CountCustomer { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Place Place { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservationBill> ReservationBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservationMealDrinkDetail> ReservationMealDrinkDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservationServiceDetail> ReservationServiceDetails { get; set; }
    }
}
