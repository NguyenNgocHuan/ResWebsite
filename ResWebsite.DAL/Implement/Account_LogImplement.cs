using ResWebsite.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResWebsite.DAL.Entity;

namespace ResWebsite.DAL.Implement
{
    public class Account_LogImplement : IAccount_Log
    {
        private RestaurantDbContext db = null;
        public Account_LogImplement()
        {
            db = new RestaurantDbContext();
        }

        public IEnumerable<Account_Log> GetAllAccount_Log()
        {
            try
            {
                return db.Account_Log;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Account_Log> GetAllAccount_Log(int page, int pageSize)
        {
            try
            {
                IQueryable<Account_Log> model = GetAllAccount_Log() as IQueryable<Account_Log>;
                model = model.OrderByDescending(x => x.EmployeeId).Skip((page - 1) * pageSize).Take(pageSize);
                return model;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<Account_Log> GetAllAccount_Log(DateTime dateTime, int page, int pageSize)
        {
            try
            {
                IQueryable<Account_Log> model = GetAllAccount_Log() as IQueryable<Account_Log>;

                if (dateTime != null)
                {
                    model = model.Where(x => x.Time.Value.Day == dateTime.Day && x.Time.Value.Month == dateTime.Month && x.Time.Value.Year == dateTime.Year);
                }
                model = model.OrderByDescending(x => x.EmployeeId).Skip((page - 1) * pageSize).Take(pageSize);
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
