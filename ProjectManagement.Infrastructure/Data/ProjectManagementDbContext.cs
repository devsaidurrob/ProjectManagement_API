using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core.Entities;

namespace ProjectManagement.Infrastructure.Data
{
    public class ProjectManagementDbContext : DbContext
    {
        public ProjectManagementDbContext(DbContextOptions<ProjectManagementDbContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Epic> Epics { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<SprintTask> SprintTasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<AcceptanceCriteria> AcceptanceCriterias { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Project and User Relationship (Owner)
            modelBuilder.Entity<Project>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.OwnerId);

            // Project Members (Many-to-Many between Users and Projects)
            modelBuilder.Entity<ProjectMember>()
                .HasOne(pm => pm.Project)
                .WithMany(p => p.ProjectMembers)
                .HasForeignKey(pm => pm.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);// Keep cascade on one

            modelBuilder.Entity<ProjectMember>()
                .HasOne(pm => pm.User)
                .WithMany()
                .HasForeignKey(pm => pm.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Epic belongs to Project
            modelBuilder.Entity<Epic>()
                .HasOne(e => e.Project)
                .WithMany(p => p.Epics)
                .HasForeignKey(e => e.ProjectId);

            // Story belongs to Epic
            modelBuilder.Entity<Story>()
                .HasOne(s => s.Epic)
                .WithMany(e => e.Stories)
                .HasForeignKey(s => s.EpicId);

            // Task belongs to Story
            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.Story)
                .WithMany(s => s.Tasks)
                .HasForeignKey(t => t.StoryId);

            // Disable cascade delete for Task -> AssignedUser
            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.AssignedUser)
                .WithMany()
                .HasForeignKey(t => t.AssignedUserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Sprint belongs to Project
            modelBuilder.Entity<Sprint>()
                .HasOne(s => s.Project)
                .WithMany(p => p.Sprints)
                .HasForeignKey(s => s.ProjectId);

            // SprintTask (Many-to-Many between Sprints and Tasks)
            modelBuilder.Entity<SprintTask>()
                .HasOne(st => st.Sprint)
                .WithMany(s => s.SprintTasks)
                .HasForeignKey(st => st.SprintId);

            modelBuilder.Entity<SprintTask>()
                .HasOne(st => st.TaskItem)
                .WithMany(t => t.SprintTasks)
                .HasForeignKey(st => st.TaskItemId)
                .OnDelete(DeleteBehavior.NoAction);

            // Acceptance Criteria belongs to Story
            modelBuilder.Entity<AcceptanceCriteria>()
                .HasOne(ac => ac.Story)
                .WithMany()
                .HasForeignKey(ac => ac.StoryId);

            // Comments belong to Task and User
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.TaskItem)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TaskItemId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Attachments belong to Task
            modelBuilder.Entity<Attachment>()
                .HasOne(a => a.TaskItem)
                .WithMany(t => t.Attachments)
                .HasForeignKey(a => a.TaskItemId);

            // Activity Log belongs to Task and User
            modelBuilder.Entity<ActivityLog>()
                .HasOne(al => al.TaskItem)
                .WithMany(t => t.ActivityLogs)
                .HasForeignKey(al => al.TaskItemId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ActivityLog>()
                .HasOne(al => al.User)
                .WithMany()
                .HasForeignKey(al => al.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}
