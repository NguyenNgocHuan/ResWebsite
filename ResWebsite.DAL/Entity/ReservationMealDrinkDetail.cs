namespace ResWebsite.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReservationMealDrinkDetail")]
    public partial class ReservationMealDrinkDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReservationContractId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(64)]
        public string MealDrinkId { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [StringLength(256)]
        public string Note { get; set; }

        public virtual MealDrink MealDrink { get; set; }

        public virtual ReservationContract ReservationContract { get; set; }
    }
}
