namespace ResWebsite.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menu()
        {
            MealDrinks = new HashSet<MealDrink>();
        }

        public int MenuId { get; set; }

        [Required]
        [StringLength(200)]
        public string MenuName { get; set; }

        public int? MealDrinkTypeId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MealDrink> MealDrinks { get; set; }

        public virtual MealDrinkType MealDrinkType { get; set; }
    }
}
