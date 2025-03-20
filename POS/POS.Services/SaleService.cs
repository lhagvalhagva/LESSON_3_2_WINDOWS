using Microsoft.EntityFrameworkCore;
using POS.Core.Models;
using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Services
{
    public interface ISaleService
    {
        Task<IEnumerable<Sale>> GetAllSalesAsync();
        Task<IEnumerable<Sale>> GetSalesByUserIdAsync(int userId);
        Task<IEnumerable<Sale>> GetSalesByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<Sale> GetSaleByIdAsync(int id);
        Task<bool> CreateSaleAsync(Sale sale);
        Task<bool> DeleteSaleAsync(int id);
    }

    public class SaleService : ISaleService
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductService _productService;

        public SaleService(ApplicationDbContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        public async Task<IEnumerable<Sale>> GetAllSalesAsync()
        {
            return await _context.Sales
                .Include(s => s.User)
                .Include(s => s.SaleItems)
                    .ThenInclude(si => si.Product)
                .OrderByDescending(s => s.SaleDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Sale>> GetSalesByUserIdAsync(int userId)
        {
            return await _context.Sales
                .Include(s => s.User)
                .Include(s => s.SaleItems)
                    .ThenInclude(si => si.Product)
                .Where(s => s.UserId == userId)
                .OrderByDescending(s => s.SaleDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Sale>> GetSalesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Sales
                .Include(s => s.User)
                .Include(s => s.SaleItems)
                    .ThenInclude(si => si.Product)
                .Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate)
                .OrderByDescending(s => s.SaleDate)
                .ToListAsync();
        }

        public async Task<Sale> GetSaleByIdAsync(int id)
        {
            return await _context.Sales
                .Include(s => s.User)
                .Include(s => s.SaleItems)
                    .ThenInclude(si => si.Product)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> CreateSaleAsync(Sale sale)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Set sale date to current time
                sale.SaleDate = DateTime.Now;

                // Add sale to database
                await _context.Sales.AddAsync(sale);
                await _context.SaveChangesAsync();

                // Update product stock quantities
                foreach (var saleItem in sale.SaleItems)
                {
                    await _productService.UpdateStockAsync(saleItem.ProductId, -saleItem.Quantity);
                }

                // Commit transaction
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                // Rollback transaction if there's any error
                await transaction.RollbackAsync();
                return false;
            }
        }

        public async Task<bool> DeleteSaleAsync(int id)
        {
            var sale = await _context.Sales
                .Include(s => s.SaleItems)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sale == null)
                return false;

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Return products to inventory
                foreach (var saleItem in sale.SaleItems)
                {
                    await _productService.UpdateStockAsync(saleItem.ProductId, saleItem.Quantity);
                }

                // Remove sale and its items
                _context.Sales.Remove(sale);
                await _context.SaveChangesAsync();

                // Commit transaction
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                // Rollback transaction if there's any error
                await transaction.RollbackAsync();
                return false;
            }
        }
    }
} 