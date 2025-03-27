using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.Entities
{
    public class ProjectMember
    {
        [Key]
        public int Id { get; set; }

        // Foreign key for Project
        public int ProjectId { get; set; }
        public virtual Project? Project { get; set; } // Made nullable

        // Foreign key for User
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!; // Added non-nullable default value

        // Role (e.g., Developer, Tester, Manager)
        public string Role { get; set; } = string.Empty; // Added default value
    }
}
