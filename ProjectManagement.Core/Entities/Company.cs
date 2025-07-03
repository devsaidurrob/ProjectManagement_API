using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<AppUser> Users { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
