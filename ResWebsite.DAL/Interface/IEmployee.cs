using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.Interface
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAllEmployee();
        bool AddEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int employeeId);
        Employee FindEmployee(int employeeId);
        bool MakeTimeKeeping(ReservationContract reservationContract);
        int GetCountUsername(string username);
        bool IsExistUsername(string username);
        Employee FindEmployee(string username);
    }
}
