using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.Entities
{
    public class UserTeam
    {
        public int UserId { get; set; }
        public virtual AppUser User { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
