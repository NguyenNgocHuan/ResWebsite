namespace ResWebsite.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Place")]
    public partial class Place
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Place()
        {
            Orders = new HashSet<Order>();
            ReservationContracts = new HashSet<ReservationContract>();
        }

        public int PlaceId { get; set; }

        [Required]
        [StringLength(256)]
        public string PlaceName { get; set; }

        [StringLength(256)]
        public string Picture { get; set; }

        [StringLength(256)]
        public string Descriptions { get; set; }

        public int PlaceTypeId { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public int? Seat { get; set; }

        public int? AvailableEat { get; set; }

        public byte? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual PlaceType PlaceType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservationContract> ReservationContracts { get; set; }
    }
}
