using ResWebsite.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ResWebsite.DAL.Implement;
using ResWebsite.DAL.Entity;

namespace ResWebsite.BLL.Bussiness
{
    public class CustomerBLL
    {
        CustomerImplement dal = new CustomerImplement();
        public bool AddCustomer(Customer customer)
        {
            try
            {
                dal.AddCustomer(customer);
                return true;
            }catch(Exception e)
            {
                return false;
                throw e;
            }
        }

        public bool DeleteCustomer(Customer customer)
        {
            if (customer != null)
            {
                dal.DeleteCustomer(customer);
                return true;

            }
            return false;
        }

        public Customer FindCustomer(int customerId)
        {
            if(customerId > 0)
            return dal.FindCustomer(customerId);
            return null;
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return dal.GetAllCustomer();
        }

        public bool UpdateCustomer(Customer customer)
        {
            if (customer != null)
            {
                dal.UpdateCustomer(customer);
                return true;
            }
            return false;
        }

        public Customer GetCustomerByEmail(string email)
        {
            if (email != "")
                return dal.GetCustomerByEmail(email);
            return null;
        }
    }
}
