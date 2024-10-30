using Microsoft.Extensions.Configuration;
using Repository;
using System;
using System.Windows;

namespace WpfApp
{
    public partial class LoginWindow : Window
    {
        private readonly ICustomerRepository customerRepository;
        private readonly string adminEmail;
        private readonly string adminPassword;

        // Default constructor
        public LoginWindow()
        {
            InitializeComponent();
            customerRepository = new CustomerRepository();
            adminEmail = string.Empty; // Default value
            adminPassword = string.Empty; // Default value
        }

        // Constructor with IConfiguration
        public LoginWindow(IConfiguration configuration) : this()
        {
            adminEmail = configuration["DefaultAdmin:Email"];
            adminPassword = configuration["DefaultAdmin:Password"];
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string userInput = txtUser.Text.Trim();

                // Check if user input matches the admin credentials
                if (userInput.Equals(adminEmail, StringComparison.OrdinalIgnoreCase) &&
                    txtPass.Password == adminPassword)
                {
                    // Login as admin
                    this.Hide();
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    return;
                }

                // Otherwise, check the customer database
                var customer = customerRepository.GetCustomerByEmailAddress(userInput);

                if (customer != null)
                {
                    if (!string.IsNullOrEmpty(txtPass.Password) && customer.Password.Equals(txtPass.Password))
                    {
                        if (customer.CustomerStatus == 1)
                        {
                            this.Hide();
                            MainWindow mainWindow = new MainWindow(customer.CustomerFullName, customer.CustomerID);
                            mainWindow.Show();
                        }
                        else if (customer.CustomerStatus == 0) // Assuming CustomerStatus of 0 is for admin users
                        {
                            this.Hide();
                            AdminWindow adminWindow = new AdminWindow();
                            adminWindow.Show();
                        }
                        else
                        {
                            MessageBox.Show("Unknown customer status.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid password!");
                    }
                }
                else
                {
                    MessageBox.Show("Account not found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
