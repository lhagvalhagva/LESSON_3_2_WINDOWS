using Microsoft.EntityFrameworkCore;
using POS.Core.Models;

namespace POS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<SaleItem>()
                .HasOne(si => si.Sale)
                .WithMany(s => s.SaleItems)
                .HasForeignKey(si => si.SaleId);

            modelBuilder.Entity<SaleItem>()
                .HasOne(si => si.Product)
                .WithMany()
                .HasForeignKey(si => si.ProductId);

            // Seed initial data
            SeedInitialData(modelBuilder);
        }

        private void SeedInitialData(ModelBuilder modelBuilder)
        {
            // Seed users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "Manager", Password = "manager123", Role = UserRole.Manager, IsActive = true },
                new User { Id = 2, Username = "Cashier1", Password = "cashier1", Role = UserRole.Cashier, IsActive = true },
                new User { Id = 3, Username = "Cashier2", Password = "cashier2", Role = UserRole.Cashier, IsActive = true }
            );

            // Seed categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Хүнсний бараа", Description = "Хүнсний төрлийн бүх бараа", IsActive = true },
                new Category { Id = 2, Name = "Ахуйн хэрэглээ", Description = "Ахуйн хэрэглээний бараанууд", IsActive = true },
                new Category { Id = 3, Name = "Цахилгаан бараа", Description = "Цахилгаан хэрэгсэл", IsActive = true }
            );

            // Seed products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Code = "P001", Name = "Талх", Description = "Өдөр тутмын талх", Price = 2000, StockQuantity = 50, CategoryId = 1, IsActive = true },
                new Product { Id = 2, Code = "P002", Name = "Сүү", Description = "Цэвэр сүү 1л", Price = 3500, StockQuantity = 30, CategoryId = 1, IsActive = true },
                new Product { Id = 3, Code = "P003", Name = "Саван", Description = "Гар саван", Price = 1500, StockQuantity = 100, CategoryId = 2, IsActive = true },
                new Product { Id = 4, Code = "P004", Name = "Угаалгын нунтаг", Description = "Ариун цэврийн хэрэгсэл", Price = 5000, StockQuantity = 40, CategoryId = 2, IsActive = true },
                new Product { Id = 5, Code = "P005", Name = "Ус буцалгагч", Description = "Цахилгаан ус буцалгагч", Price = 45000, StockQuantity = 10, CategoryId = 3, IsActive = true }
            );
        }
    }
} 