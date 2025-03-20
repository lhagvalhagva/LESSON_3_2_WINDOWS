namespace POS.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; } = true;
        
        // Foreign key
        public int CategoryId { get; set; }
        
        // Navigation property
        public virtual Category? Category { get; set; }
    }
} 