using ResWebsite.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResWebsite.DAL.Entity;

namespace ResWebsite.DAL.Implement
{
    public class EmployeeImplement : IEmployee
    {
        private RestaurantDbContext db = null;

        public EmployeeImplement()
        {
            db = new RestaurantDbContext();
        }

        public bool AddEmployee(Employee employee)
        {
            try
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            return true;
        }

        public Employee FindEmployee(string username)
        {
            try
            {
                return db.Employees.SingleOrDefault(x => x.Username == username);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Employee FindEmployee(int employeeId)
        {
            try
            {
                return db.Employees.SingleOrDefault(x => x.EmployeeId == employeeId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            try
            {
                return db.Employees;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCountUsername(string username)
        {
            try
            {
                var count = db.Employees.Where(x => x.Username == username).ToList();
                return count.Count();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsExistUsername(string username)
        {
            try
            {
                var result = db.Employees.SingleOrDefault(x => x.Username == username);
                if (result != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        bool IEmployee.MakeTimeKeeping(ReservationContract reservationContract)
        {
            throw new NotImplementedException();
        }

        bool MakeTimeKeeping(ReservationContract reservationContract)
        {
            throw new NotImplementedException();
        }
    }
}
