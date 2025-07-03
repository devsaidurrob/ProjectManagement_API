using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.Entities
{
    public class AppRole
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public virtual ICollection<AppUserRole> UserRoles { get; set; } = new List<AppUserRole>();
    }
}
