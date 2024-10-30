using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using System;
using System.Windows;

namespace WpfApp
{
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            // Set up configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Set up dependency injection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, configuration);
            serviceProvider = serviceCollection.BuildServiceProvider();

            base.OnStartup(e);

            // Resolve and show LoginWindow
            var loginWindow = serviceProvider.GetService<LoginWindow>();
            if (loginWindow != null)
            {
                loginWindow.Show();
            }
            else
            {
                MessageBox.Show("Failed to load LoginWindow.");
            }
        }

        private void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration); // Register IConfiguration
            services.AddSingleton<ICustomerRepository, CustomerRepository>(); // Register your repository
            services.AddTransient<LoginWindow>(); // Register LoginWindow for DI
            services.AddTransient<MainWindow>(); // Register MainWindow
            services.AddTransient<AdminWindow>(); // Register AdminWindow
        }
    }
}
