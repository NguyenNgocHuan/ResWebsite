namespace ResWebsite.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MealDrink")]
    public partial class MealDrink
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MealDrink()
        {
            OrderMealDrinkDetails = new HashSet<OrderMealDrinkDetail>();
            ReservationMealDrinkDetails = new HashSet<ReservationMealDrinkDetail>();
        }

        [StringLength(64)]
        public string MealDrinkId { get; set; }

        public int MenuId { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(256)]
        public string Descriptions { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [StringLength(256)]
        public string Picture { get; set; }

        public int? UnitId { get; set; }

        public virtual Menu Menu { get; set; }

        public virtual Unit Unit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderMealDrinkDetail> OrderMealDrinkDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservationMealDrinkDetail> ReservationMealDrinkDetails { get; set; }
    }
}
