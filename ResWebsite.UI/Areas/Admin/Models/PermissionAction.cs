using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResWebsite.UI.Areas.Admin.Models
{
    public class PermissionAction
    {
        public int PermissionId { set; get; }
        public string PermissionName { set; get; }
        public string Description { set; get; }
        public bool IsGranted { set; get; }
    }
}