using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.Entities
{
    public class ActivityLog
    {
        [Key]
        public int Id { get; set; }
        public int TaskItemId { get; set; }
        public virtual TaskItem? TaskItem { get; set; } // Made nullable
        public int UserId { get; set; }
        public virtual User User { get; set; } = new User();
        public string Action { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }
}
