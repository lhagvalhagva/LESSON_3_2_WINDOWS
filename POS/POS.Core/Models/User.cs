using System.Collections.Generic;

namespace POS.Core.Models
{
    public enum UserRole
    {
        Manager,
        Cashier
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public bool IsActive { get; set; } = true;
    }
} 