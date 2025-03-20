using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using POS.Data;
using POS.Services;
using System;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using POS.Core.Models;

namespace POS.UI
{
    internal static class Program
    {
        // Глобал сервис үүсгэгч
        public static IServiceProvider? ServiceProvider { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();

            using (var serviceScope = ServiceProvider.CreateScope())
            {
                var loginForm = serviceScope.ServiceProvider.GetRequiredService<LoginForm>();
                Application.Run(loginForm);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pos.db");
            string connectionString = $"Data Source={dbPath}";

            // Register db context
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString));

            // Create database and tables if not exists
            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    dbContext.Database.EnsureCreated();
                    
                    // Seed initial data if needed
                    SeedInitialData(dbContext);
                }
            }

            // Register repositories
            // If needed, add repositories here

            // Register services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<IReceiptService, ReceiptService>();

            // Register forms
            services.AddTransient<LoginForm>();
            services.AddTransient<MainForm>();
            services.AddTransient<UsersForm>();
            services.AddTransient<CategoriesForm>();
            services.AddTransient<ProductsForm>();
            services.AddTransient<SalesForm>();
            services.AddTransient<AddProductForm>();
            services.AddTransient<HelpForm>();
            services.AddTransient<AddCategoryForm>();
        }

        private static void SeedInitialData(ApplicationDbContext dbContext)
        {
            // Check if the database already has users
            if (!dbContext.Users.Any())
            {
                // Add default admin user
                dbContext.Users.Add(new User
                {
                    Username = "admin",
                    Password = "admin123", // In a real application, this should be hashed
                    Role = UserRole.Manager,
                    IsActive = true
                });

                // Add default cashier user
                dbContext.Users.Add(new User
                {
                    Username = "cashier",
                    Password = "cashier123", // In a real application, this should be hashed
                    Role = UserRole.Cashier,
                    IsActive = true
                });

                dbContext.SaveChanges();
            }
        }
    }
}