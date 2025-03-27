using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.Entities
{
    public class Attachment
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public int TaskItemId { get; set; }
        public virtual TaskItem TaskItem { get; set; } = new TaskItem();
        public DateTime UploadedAt { get; set; }
    }
}
