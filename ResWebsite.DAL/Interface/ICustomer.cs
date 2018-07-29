using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.Interface
{
    public interface ICustomer
    {
        IEnumerable<Customer> GetAllCustomer();
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customerId);
        Customer FindCustomer(int customerId);
        
    }
}
