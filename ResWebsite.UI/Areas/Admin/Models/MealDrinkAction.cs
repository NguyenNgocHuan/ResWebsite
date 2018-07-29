using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResWebsite.UI.Areas.Admin.Models
{
    public class MealDrinkAction
    {
        public string MealDrinkId { set; get; }
        public int? MenuId { set; get; }

        public string Descriptions { set; get; }
        public int? UnitId { set; get; }
        public string UnitName { set; get; }
        public decimal Price { set; get; }
        public string Name { set; get; }
        public string Picture { set; get; }
        public string MenuName { set; get; }
    }
}