namespace ResWebsite.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            ReservationContracts = new HashSet<ReservationContract>();
        }

        public int CustomerId { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(64)]
        public string Phone { get; set; }

        [StringLength(64)]
        public string Email { get; set; }

        public bool? Deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservationContract> ReservationContracts { get; set; }
    }
}
