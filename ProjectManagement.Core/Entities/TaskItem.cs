﻿using ProjectManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProjectManagement.Core.Entities
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int StoryId { get; set; }
        public Enums.TaskStatus Status { get; set; }  // NEW
        public bool IsCompleted => Status == Enums.TaskStatus.Done; // Optional derived
        public Priority Priority { get; set; }
        public int AssignedUserId { get; set; } // Assigned user
        public int ProjectId { get; set; }
        public int EpicId { get; set; }
        public TaskTag Tag { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Estimate { get; set; }
        public string? EstimateUnit { get; set; }
        public virtual Story Story { get; set; }
        public virtual AppUser AssignedUser { get; set; }
        public virtual ICollection<SprintTask> SprintTasks { get; set; } // Linking with Sprint
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }
    }
}
