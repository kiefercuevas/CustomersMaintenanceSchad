using CustomersMaintenanceSchad.Data;
using CustomersMaintenanceSchad.Services;
using CustomersMaintenanceSchad.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;

namespace CustomersMaintenanceSchad
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IConfiguration Configuration { get; set; }
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            //Configuring user secrets
            IConfigurationBuilder builder = new ConfigurationBuilder();
            _ = builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddUserSecrets<ConnectionStrings>();

            Configuration = builder.Build();

            ServiceProvider = GetConfiguredServices().BuildServiceProvider();
        }

        private IServiceCollection GetConfiguredServices()
        {
            ServiceCollection services = new ServiceCollection();

            //Getting the conection string from user secrets
            string conectionString = Configuration.GetConnectionString(nameof(ConnectionStrings.TestInvoice));

            //Adding DBContext
            _ = services.AddDbContext<TestInvoiceDbContext>(options => options.UseSqlServer(conectionString));

            //Adding Services
            _ = services.AddSingleton<ICustomerTypeService, CustomerTypeService>();
            _ = services.AddSingleton<ICustomerService, CustomerService>();
            _ = services.AddSingleton<IInvoiceService, InvoiceService>();


            return services;
        }

        public static T GetServiceInstance<T>()
        {
            return ((App)Current).ServiceProvider.GetRequiredService<T>();
        }

    }

}
