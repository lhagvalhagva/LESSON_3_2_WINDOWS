using System;
using System.Collections.Generic;

namespace POS.Core.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountTendered { get; set; }
        public decimal Change { get; set; }
        
        // Foreign key
        public int UserId { get; set; }
        
        // Navigation properties
        public virtual User User { get; set; }
        public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }
} 