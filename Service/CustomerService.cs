using BussinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CustomerService : ICustomerRepository
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public List<Customer> GetAllCustomers()
        {
            return customerRepository.GetAllCustomers();
        }

        public Customer GetCustomerById(int id)
        {
            return customerRepository.GetCustomerById(id);
        }

        public Customer GetCustomerByEmailAddress(String email)
        {
            return customerRepository.GetCustomerByEmailAddress(email);
        }
        public void AddCustomer(Customer customer)
        {
            customerRepository.AddCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            customerRepository.UpdateCustomer(customer);
        }

        public void DeleteCustomer(int id)
        {
            customerRepository.DeleteCustomer(id);
        }
    }
}
