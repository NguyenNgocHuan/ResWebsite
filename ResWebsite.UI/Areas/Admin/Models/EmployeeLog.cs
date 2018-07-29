using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ResWebsite.UI.Areas.Admin.Models
{
    public class EmployeeLog
    {
        RestaurantDbContext db = new RestaurantDbContext();

        public string GetIpAddress()
        {
            string CIP="";
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress item in host.AddressList)
            {
                if (item.AddressFamily.ToString() == "InterNetwork")
                {
                    CIP = item.ToString();
                }
            }
            return CIP;
        }

        public bool AddAccountLog(Account_Log accountLog)
        {
            if (accountLog == null)
            {
                return false;
            }
            else
            {
                db.Account_Log.Add(accountLog);
                db.SaveChanges();
                return true;
            }
        }

        public bool AddEmployeeActivityLog(Employee_Activity_Log employeeActivityLog)
        {
            if (employeeActivityLog == null)
            {
                return false;
            }
            else
            {
                db.Employee_Activity_Log.Add(employeeActivityLog);
                db.SaveChanges();
                return true;
            }
        }

        public bool AddEmployeeActivityLog(Employee employee,int employeeId,string action,string method, string information)
        {

            string ipAddress = GetIpAddress();
            string timeStr = DateTime.Now.ToString();
            DateTime time = DateTime.Parse(timeStr);

            Employee_Activity_Log employeeActivityLog = new Employee_Activity_Log()
            {
                Action = action,
                EmployeeId = employeeId,
                Method = method,
                Information = information,
                Time = time,
                IpAddress = ipAddress
            };
            if (employeeActivityLog == null)
            {
                return false;
            }
            else
            {
                db.Employee_Activity_Log.Add(employeeActivityLog);
                db.SaveChanges();
                return true;
            }
        }
    }
}