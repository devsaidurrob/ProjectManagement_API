using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int TaskItemId { get; set; }
        public virtual TaskItem TaskItem { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
