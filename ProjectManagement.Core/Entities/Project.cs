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
        public int OwnerId { get; set; } // User who owns the project
        public virtual ICollection<Epic> Epics { get; set; } = new List<Epic>(); // Initialize with a default value
        public virtual ICollection<Sprint> Sprints { get; set; } = new List<Sprint>(); // Initialize with a default value
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>(); // Initialize with a default value
    }
}
