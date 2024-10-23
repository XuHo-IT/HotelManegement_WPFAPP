using BussinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal class CustomerDAO
    {
        private string connectionString;

        public CustomerDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customer";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer
                        {
                            CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                            CustomerFullName = reader.GetString(reader.GetOrdinal("CustomerFullName")),
                            Telephone = reader.GetString(reader.GetOrdinal("Telephone")),
                            EmailAddress = reader.GetString(reader.GetOrdinal("EmailAddress")),
                            CustomerBirthday = reader.IsDBNull(reader.GetOrdinal("CustomerBirthday")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CustomerBirthday")),
                            CustomerStatus = reader.IsDBNull(reader.GetOrdinal("CustomerStatus")) ? (byte?)null : reader.GetByte(reader.GetOrdinal("CustomerStatus")),
                            Password = reader.GetString(reader.GetOrdinal("Password"))
                        };
                        customers.Add(customer);
                    }
                }
            }
            return customers;
        }
    }
}
