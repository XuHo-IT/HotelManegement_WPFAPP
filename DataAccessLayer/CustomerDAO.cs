using BussinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomerDAO
    {

        private static CustomerDAO? instance = null;
        private static readonly object instanceLock = new object();
        private HotelManagementContext _context;

        public static CustomerDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDAO();
                    }
                    return instance;
                }
            }
        }


        private CustomerDAO() { }

        public List<Customer> GetAllCustomers()
        {
            using (var _context = new HotelManagementContext())
            {
                return _context.Customers.ToList();
            }
        }
        public Customer GetCustomerById(int id)
        {
            using (var _context = new HotelManagementContext())
            {
                return _context.Customers.Find(id);
            }
        }
        public Customer GetCustomerByEmailAddress(string emailAddress)
        {
            using (var _context = new HotelManagementContext())
            {
                return _context.Customers
                    .FirstOrDefault(c => c.EmailAddress == emailAddress);
            }
        }
        public void AddCustomer(Customer customer)
        {
            using (var _context = new HotelManagementContext())
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
        }
        public void UpdateCustomer(Customer customer)
        {
            using (var _context = new HotelManagementContext())
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();
            }
        }
        public void DeleteCustomer(int id)
        {
            using (var _context = new HotelManagementContext())
            {
                var customer = _context.Customers.Find(id);
                if (customer != null)
                {
                    _context.Customers.Remove(customer);
                    _context.SaveChanges();
                }
            }
        }
    }
}
