using BussinessObject;
using DataAccessLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Repository
    {
    public class CustomerRepository : ICustomerRepository
    {
        public void AddCustomer(Customer customer) => CustomerDAO.Instance.AddCustomer(customer);


        public void DeleteCustomer(int id)=> CustomerDAO.Instance.DeleteCustomer(id);

        public List<Customer> GetAllCustomers() => CustomerDAO.Instance.GetAllCustomers();


        public Customer GetCustomerByEmailAddress(string email) => CustomerDAO.Instance.GetCustomerByEmailAddress(email);
 
        public Customer GetCustomerById(int id) => CustomerDAO.Instance.GetCustomerById(id);

        public void UpdateCustomer(Customer customer) => CustomerDAO.Instance.UpdateCustomer(customer);     
    }
}
