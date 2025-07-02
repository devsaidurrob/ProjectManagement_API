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
        public DbSet<AppUser> Users { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<AcceptanceCriteria> AcceptanceCriterias { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }

        public DbSet<AppUserRole> UserRoles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<UserTeam> UserTeams { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<AppRole> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Project and User Relationship (Owner)
            modelBuilder.Entity<Project>()
                .HasOne<AppUser>()
                .WithMany()
                .HasForeignKey(p => p.CompanyId);

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

            // AppUser - Unique Indexes
            modelBuilder.Entity<AppUser>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<AppUser>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<AppUser>()
                .HasIndex(u => u.MobileNumber)
                .IsUnique();

            // AppUserRole - Composite PK
            modelBuilder.Entity<AppUserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<AppUserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<AppUserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            // ProjectMember - Composite PK
            modelBuilder.Entity<ProjectMember>()
                .HasIndex(pm => new { pm.ProjectId, pm.UserId })
                .IsUnique();

            modelBuilder.Entity<ProjectMember>()
                .HasOne(pm => pm.Project)
                .WithMany(p => p.ProjectMembers)
                .HasForeignKey(pm => pm.ProjectId);

            modelBuilder.Entity<ProjectMember>()
                .HasOne(pm => pm.User)
                .WithMany(u => u.ProjectMembers)
                .HasForeignKey(pm => pm.UserId);

            // UserTeam - Composite PK
            modelBuilder.Entity<UserTeam>()
                .HasKey(ut => new { ut.TeamId, ut.UserId });

            modelBuilder.Entity<UserTeam>()
                .HasOne(ut => ut.Team)
                .WithMany(t => t.UserTeams)
                .HasForeignKey(ut => ut.TeamId);

            modelBuilder.Entity<UserTeam>()
                .HasOne(ut => ut.User)
                .WithMany()
                .HasForeignKey(ut => ut.UserId);

            // Team → Company
            modelBuilder.Entity<Team>()
                .HasOne(t => t.Company)
                .WithMany(c => c.Teams)
                .HasForeignKey(t => t.CompanyId);

            // Project → Company
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Company)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.CompanyId);

            // AppUser → Company
            modelBuilder.Entity<AppUser>()
                .HasOne<Company>()
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CompanyId);

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}
