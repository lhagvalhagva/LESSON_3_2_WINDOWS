using System.Collections.Generic;

namespace POS.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        
        // Navigation property
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
} 