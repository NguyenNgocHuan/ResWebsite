namespace ResWebsite.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderMealDrinkDetails = new HashSet<OrderMealDrinkDetail>();
            OrderServiceDetails = new HashSet<OrderServiceDetail>();
        }

        public int OrderId { get; set; }

        public int PlaceId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "money")]
        public decimal Total { get; set; }

        public byte? status { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderMealDrinkDetail> OrderMealDrinkDetails { get; set; }

        public virtual Place Place { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderServiceDetail> OrderServiceDetails { get; set; }
    }
}
