using Repository;
using Service; // Added Service namespace for CustomerService
using System;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WpfApp
{
   
    public partial class LoginWindow : System.Windows.Window
    {
        private readonly ICustomerRepository customerService;

        public LoginWindow()
        {
            InitializeComponent();
            var connectionString = "Server=(local); Database=HotelManagement; Uid=sa; Pwd=sa123; TrustServerCertificate=True";
            var customerRepository = new CustomerRepository(connectionString);
            customerService = new CustomerService(customerRepository);  
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string userInput = txtUser.Text.Trim();

             
                var customer = customerService.GetCustomerByEmailAddress(userInput);

        
                if (customer != null)
                {
                
                    if (!string.IsNullOrEmpty(txtPass.Password) && customer.Password.Equals(txtPass.Password))
                    {
                      
                        if (customer.CustomerStatus == 1) 
                        {
                            this.Hide();  // Hide the current window
                            MainWindow mainWindow = new MainWindow(customer.CustomerFullName,customer.CustomerID);
                            mainWindow.Show();  // Show the main window
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
