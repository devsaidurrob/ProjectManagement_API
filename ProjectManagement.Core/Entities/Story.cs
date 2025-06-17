using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.Entities
{
    public class Story
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int EpicId { get; set; }
        public Enums.TaskStatus Status { get; set; } // NEW
        public virtual Epic Epic { get; set; } = new Epic();
        public virtual ICollection<TaskItem> Tasks { get; set; }
    }
}
