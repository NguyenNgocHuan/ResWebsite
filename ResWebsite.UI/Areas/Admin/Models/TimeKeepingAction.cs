using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResWebsite.UI.Areas.Admin.Models
{
    public class TimeKeepingAction
    {
        public int TimeKeepingId { set; get; }
        public int ShiftId { set; get; }

        public string ShiftName { set; get; }
        public int EmployeeId { set; get; }
        public DateTime Date { set; get; }
        public TimeSpan? TimeIn { set; get; }
        public TimeSpan? TimeOut { set; get; }
        public bool IsGranted { set; get; }
    }
}