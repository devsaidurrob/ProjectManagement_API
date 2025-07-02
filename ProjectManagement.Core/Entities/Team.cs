using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.Entities
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<UserTeam> UserTeams { get; set; }
    }
}
