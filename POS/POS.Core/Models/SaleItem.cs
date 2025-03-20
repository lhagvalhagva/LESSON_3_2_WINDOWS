namespace POS.Core.Models
{
    public class SaleItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
        
        // Foreign keys
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        
        // Navigation properties
        public virtual Sale Sale { get; set; }
        public virtual Product Product { get; set; }
    }
} 