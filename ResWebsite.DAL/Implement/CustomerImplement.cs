using ResWebsite.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResWebsite.DAL.Entity;

namespace ResWebsite.DAL.Implement
{
    public class CustomerImplement : ICustomer
    {
        RestaurantDbContext db = new RestaurantDbContext();
        public void AddCustomer(Customer customer)
        {
             db.Customers.Add(customer);
             db.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
                db.Customers.Remove(customer);
                db.SaveChanges();
        }

        public Customer FindCustomer(int customerId)
        {
            return db.Customers.Find(customerId) == null ? null : db.Customers.Find(customerId);
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return db.Customers;
        }

        public void UpdateCustomer(Customer customer)
        {
            db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Customer GetCustomerByEmail(string email)
        {
            return db.Customers.Where(x=>x.Email == email).FirstOrDefault();
        }
    }
}
