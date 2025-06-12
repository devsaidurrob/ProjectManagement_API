using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.Entities
{
    public class SprintTask
    {
        [Key]
        public int Id { get; set; }
        public int SprintId { get; set; }
        public virtual Sprint Sprint { get; set; }
        public int TaskItemId { get; set; }
        public virtual TaskItem TaskItem { get; set; }
    }
}
