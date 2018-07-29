namespace ResWebsite.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service()
        {
            OrderServiceDetails = new HashSet<OrderServiceDetail>();
            ReservationServiceDetails = new HashSet<ReservationServiceDetail>();
        }

        [StringLength(64)]
        public string ServiceId { get; set; }

        [StringLength(256)]
        public string ServiceName { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public int ServiceTypeId { get; set; }

        public bool? Deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderServiceDetail> OrderServiceDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservationServiceDetail> ReservationServiceDetails { get; set; }

        public virtual ServiceType ServiceType { get; set; }
    }
}
