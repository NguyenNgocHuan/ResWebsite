using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResWebsite.UI.Areas.Admin.Models
{
    public class Account_LogAction
    {
        public string EmployeeName { set; get; }
        public string Action { set; get; }
        public string Time { set; get; }
        public string IpAddress { set; get; }
    }
}