using BussinessObject;
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
            private readonly string connectionString;

            public CustomerRepository(string connectionString)
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

            public Customer GetCustomerById(int id)
            {
                Customer customer = null;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Customer WHERE CustomerID = @id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new Customer
                            {
                                CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                                CustomerFullName = reader.GetString(reader.GetOrdinal("CustomerFullName")),
                                Telephone = reader.GetString(reader.GetOrdinal("Telephone")),
                                EmailAddress = reader.GetString(reader.GetOrdinal("EmailAddress")),
                                CustomerBirthday = reader.IsDBNull(reader.GetOrdinal("CustomerBirthday")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CustomerBirthday")),
                                CustomerStatus = reader.IsDBNull(reader.GetOrdinal("CustomerStatus")) ? (byte?)null : reader.GetByte(reader.GetOrdinal("CustomerStatus")),
                                Password = reader.GetString(reader.GetOrdinal("Password"))
                            };
                        }
                    }
                }
                return customer;
            }
        public Customer GetCustomerByEmailAddress(string emailAddress)
        {
            Customer customer = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customer WHERE EmailAddress = @EmailAddress";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmailAddress", emailAddress);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        customer = new Customer
                        {
                            CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                            CustomerFullName = reader.GetString(reader.GetOrdinal("CustomerFullName")),
                            Telephone = reader.GetString(reader.GetOrdinal("Telephone")),
                            EmailAddress = reader.GetString(reader.GetOrdinal("EmailAddress")),
                            CustomerBirthday = reader.IsDBNull(reader.GetOrdinal("CustomerBirthday")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CustomerBirthday")),
                            CustomerStatus = reader.IsDBNull(reader.GetOrdinal("CustomerStatus")) ? (byte?)null : reader.GetByte(reader.GetOrdinal("CustomerStatus")),
                            Password = reader.GetString(reader.GetOrdinal("Password"))
                        };
                    }
                }
            }
            return customer;
        }


        public void AddCustomer(Customer customer)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Customer (CustomerFullName, Telephone, EmailAddress, CustomerBirthday, CustomerStatus, Password) VALUES (@CustomerFullName, @Telephone, @EmailAddress, @CustomerBirthday, @CustomerStatus, @Password)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CustomerFullName", customer.CustomerFullName);
                    command.Parameters.AddWithValue("@Telephone", customer.Telephone);
                    command.Parameters.AddWithValue("@EmailAddress", customer.EmailAddress);
                    command.Parameters.AddWithValue("@CustomerBirthday", customer.CustomerBirthday);
                    command.Parameters.AddWithValue("@CustomerStatus", customer.CustomerStatus);
                    command.Parameters.AddWithValue("@Password", customer.Password);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            public void UpdateCustomer(Customer customer)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Customer SET CustomerFullName = @CustomerFullName, Telephone = @Telephone, EmailAddress = @EmailAddress, CustomerBirthday = @CustomerBirthday, CustomerStatus = @CustomerStatus, Password = @Password WHERE CustomerID = @CustomerID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CustomerFullName", customer.CustomerFullName);
                    command.Parameters.AddWithValue("@Telephone", customer.Telephone);
                    command.Parameters.AddWithValue("@EmailAddress", customer.EmailAddress);
                    command.Parameters.AddWithValue("@CustomerBirthday", customer.CustomerBirthday);
                    command.Parameters.AddWithValue("@CustomerStatus", customer.CustomerStatus);
                    command.Parameters.AddWithValue("@Password", customer.Password);
                    command.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            public void DeleteCustomer(int id)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Customer WHERE CustomerID = @id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
