using ResWebsite.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResWebsite.DAL.Entity;
using ResWebsite.DAL.Implement;
using System.Web.UI.WebControls;
using PagedList;

namespace ResWebsite.BLL.Bussiness
{
    public class EmployeeBLL : IEmployee
    {
        private EmployeeImplement dal = new EmployeeImplement();

        public bool AddEmployee(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    if (string.IsNullOrEmpty(employee.Username))
                    {
                        return dal.AddEmployee(employee);
                    }
                    else
                    {
                        if (IsExistUsername(employee.Username) == false)
                        {
                            return dal.AddEmployee(employee);
                        }
                    }

                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            return false;
        }
        public Employee FindEmployee(int employeeId)
        {
            try
            {
                if (string.IsNullOrEmpty(employeeId.ToString()))
                {
                    return null;
                }
                else
                    return dal.FindEmployee(employeeId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Employee FindEmployee(string username)
        {
            try
            {
                if (string.IsNullOrEmpty(username))
                {
                    return null;
                }
                else
                    return dal.FindEmployee(username);
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
                return dal.GetAllEmployee();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Employee> GetAllEmployee(int page, int pageSize, string searchString)
        {
            return null;
            
        }

        public int GetCountUsername(string username)
        {
            try
            {
                return dal.GetCountUsername(username);
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
                return dal.IsExistUsername(username);
            }
            catch (Exception)
            {

                throw;
            }
        }
        

        public int Login(string username, string password)
        {
            return 0;
        }

        public bool MakeTimeKeeping(ReservationContract reservationContract)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    var employeeExist = FindEmployee(employee.EmployeeId);
                    if (employeeExist == null)
                    {
                        return false;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(employee.Username))
                        {
                            return dal.UpdateEmployee(employee);
                        }
                        else
                        {
                            if (GetCountUsername(employee.Username) == 1 && employeeExist.Username == employee.Username)
                            {
                                return dal.UpdateEmployee(employee);
                            }
                            else
                                return false;
                        }
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
