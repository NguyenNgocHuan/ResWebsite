using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResWebsite.UI.Areas.Admin.Models
{
    public class ShiftAction
    {
        public int ShiftId { set; get; }
        public string ShiftName { set; get; }
        public bool IsGranted { set; get; }
    }
}