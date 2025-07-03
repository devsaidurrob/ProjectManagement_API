using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Initialize with a default value
        public string Description { get; set; } = string.Empty; // Initialize with a default value
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CompanyId { get; set; } // User who owns the project
        public virtual Company Company { get; set; } // Navigation property for the company
        public virtual ICollection<Epic> Epics { get; set; } // Initialize with a default value
        public virtual ICollection<Sprint> Sprints { get; set; } // Initialize with a default value
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; } // Initialize with a default value
    }
}
