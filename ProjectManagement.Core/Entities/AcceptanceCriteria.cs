using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.Entities
{
    public class AcceptanceCriteria
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty; // Initialize with a default value
        public int StoryId { get; set; }
        public virtual Story Story { get; set; } = new Story(); // Initialize with a default value
        public bool IsMet { get; set; }
    }
}
