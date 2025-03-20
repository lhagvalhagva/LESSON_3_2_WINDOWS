using POS.Core.Models;
using System;
using System.Text;
using System.Threading.Tasks;

namespace POS.Services
{
    public interface IReceiptService
    {
        Task<string> GenerateReceiptAsync(Sale sale);
        Task<bool> PrintReceiptAsync(Sale sale);
    }

    public class ReceiptService : IReceiptService
    {
        private readonly ISaleService _saleService;

        public ReceiptService(ISaleService saleService)
        {
            _saleService = saleService;
        }

        public async Task<string> GenerateReceiptAsync(Sale sale)
        {
            if (sale == null)
                return string.Empty;

            // Get the complete sale details if not already loaded
            if (sale.SaleItems.Count == 0)
            {
                sale = await _saleService.GetSaleByIdAsync(sale.Id);
                if (sale == null)
                    return string.Empty;
            }

            var sb = new StringBuilder();

            // Header
            sb.AppendLine("==================================");
            sb.AppendLine("             ПОС СИСТЕМ          ");
            sb.AppendLine("==================================");
            sb.AppendLine($"Дугаар: {sale.Id}");
            sb.AppendLine($"Огноо: {sale.SaleDate.ToString("yyyy-MM-dd HH:mm:ss")}");
            sb.AppendLine($"Ажилтан: {sale.User?.Username ?? "Unknown"}");
            sb.AppendLine("----------------------------------");

            // Items
            sb.AppendLine("Бараа            Тоо  Үнэ   Дүн");
            sb.AppendLine("----------------------------------");

            foreach (var item in sale.SaleItems)
            {
                string productName = item.Product?.Name ?? "Unknown";
                if (productName.Length > 15)
                    productName = productName.Substring(0, 12) + "...";
                else
                    productName = productName.PadRight(15);

                sb.AppendLine($"{productName} {item.Quantity,3} {item.UnitPrice,6:N0} {item.Subtotal,7:N0}");
            }

            // Summary
            sb.AppendLine("----------------------------------");
            sb.AppendLine($"Нийт дүн:                {sale.TotalAmount,8:N0}");
            sb.AppendLine($"Төлсөн:                  {sale.AmountTendered,8:N0}");
            sb.AppendLine($"Хариулт:                 {sale.Change,8:N0}");
            sb.AppendLine("==================================");
            sb.AppendLine("        Баярлалаа !              ");
            sb.AppendLine("==================================");

            return sb.ToString();
        }

        public async Task<bool> PrintReceiptAsync(Sale sale)
        {
            try
            {
                string receipt = await GenerateReceiptAsync(sale);
                
                // In a real application, this would send the receipt to a printer
                // For simplicity, we'll just return true if we have a receipt
                return !string.IsNullOrEmpty(receipt);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
} 