using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResWebsite.UI.Areas.Admin.Models
{
    public class SalariesAction
    {
        public int TimeKeepingId { set; get; }
        public int ShiftId { set; get; }

        public string ShiftName { set; get; }

        public decimal BasicSalary { set; get; }
        public decimal Bonus { set; get; }
        public decimal Subsidy { set; get; }
        public int EmployeeId { set; get; }
        public string EmployeeName { set; get; }
        public DateTime Date { set; get; }
        public TimeSpan? TimeIn { set; get; }
        public TimeSpan? TimeOut { set; get; }
    }
}