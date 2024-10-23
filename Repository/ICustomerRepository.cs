using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICustomerRepository
    {
            List<Customer> GetAllCustomers();
            Customer GetCustomerById(int id);
            Customer GetCustomerByEmailAddress(String email);
            void AddCustomer(Customer customer);
            void UpdateCustomer(Customer customer);
            void DeleteCustomer(int id);
    }
}
