using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.Entities
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string Username { get; set; } = string.Empty; // Unique username
        [MaxLength(15)]
        public string MobileNumber { get; set; } = string.Empty;
        public string? PasswordHash { get; set; }

        public string AuthProvider { get; set; } = "Local"; // Google, Microsoft, Local

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Optional company/tenant support
        public int? CompanyId { get; set; } = 1;

        // Navigation properties
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
    }
}
