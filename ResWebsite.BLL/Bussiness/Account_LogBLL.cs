using ResWebsite.DAL.Entity;
using ResWebsite.DAL.Implement;
using ResWebsite.UI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.BLL.Bussiness
{
    public class Account_LogBLL
    {
        private Account_LogImplement dal = null;
        public Account_LogBLL()
        {
            dal = new Account_LogImplement();
        }
        

        public List<Account_LogAction> GetAllAccount_Log(int page, int pageSize)
        {
            try
            {
                if(page>=0 && page >= 0)
                {
                    IEnumerable<Account_Log> model = dal.GetAllAccount_Log(page, pageSize);
                    List<Account_LogAction> lst = new List<Account_LogAction>();
                    foreach (var item in model)
                    {
                        Account_LogAction a = new Account_LogAction()
                        {
                            EmployeeName = item.Employee.EmployeeName,
                            Action = item.Action,
                            IpAddress = item.IpAddress,
                            Time = item.Time.ToString()
                        };
                        lst.Add(a);
                    }
                    return lst;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Account_LogAction> GetAllAccount_Log(DateTime dateTime, int page, int pageSize)
        {
            try
            {
                if(dateTime!=null && page>=0 && pageSize >= 0)
                {
                    IEnumerable<Account_Log> model = dal.GetAllAccount_Log(dateTime, page, pageSize);
                    List<Account_LogAction> lst = new List<Account_LogAction>();
                    foreach (var item in model)
                    {
                        Account_LogAction a = new Account_LogAction()
                        {
                            EmployeeName = item.Employee.EmployeeName,
                            Action = item.Action,
                            IpAddress = item.IpAddress,
                            Time = item.Time.ToString()
                        };
                        lst.Add(a);
                    }
                    return lst;
                }
               else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
