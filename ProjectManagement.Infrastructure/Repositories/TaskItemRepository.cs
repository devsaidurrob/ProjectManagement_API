using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Data;
using ProjectManagement.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly ProjectManagementDbContext _context;

        public TaskItemRepository(ProjectManagementDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItem?> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks
                .Include(t => t.Story)
                .Include(t => t.AssignedUser)
                .Include(t => t.Comments)
                .Include(t => t.Attachments)
                .Include(t => t.ActivityLogs)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            return await _context.Tasks
                .Include(t => t.AssignedUser)
                .ToListAsync();
        }
        public async Task<IEnumerable<TaskItem>> GetTasksByProjectAsync(int projectId)
        {
            return await _context.Tasks
                .Where(x => x.ProjectId == projectId)
                .Include(t => t.AssignedUser)
                .ToListAsync();
        }

        public async Task<IEnumerable<TaskItem>> GetTasksByStoryIdAsync(int storyId)
        {
            return await _context.Tasks
                .Where(t => t.StoryId == storyId)
                .Include(t => t.Story)
                .Include(t => t.AssignedUser)
                .Include(t => t.Comments)
                .Include(t => t.Attachments)
                .Include(t => t.ActivityLogs)
                .ToListAsync();
        }

        public async Task<TaskItem> AddTaskAsync(TaskItem taskItem)
        {
            await _context.Tasks.AddAsync(taskItem);
            return taskItem;
        }

        public async Task<TaskItem?> UpdateTaskAsync(TaskItem taskItem)
        {
            var existingTaskItem = await _context.Tasks.FindAsync(taskItem.Id);

            if (existingTaskItem == null)
            {
                return null; // Or throw an exception
            }

            _context.Entry(existingTaskItem).CurrentValues.SetValues(taskItem);
            _context.Entry(existingTaskItem).State = EntityState.Modified;
            return existingTaskItem;
        }

        public async Task<TaskItem?> DeleteTaskAsync(int id)
        {
            var existingTaskItem = await _context.Tasks
                                .Include(t => t.Attachments)
                                .Include(t => t.Comments)
                                .Include(t => t.SprintTasks)
                                .Include(t => t.ActivityLogs)
                                .FirstOrDefaultAsync(t => t.Id == id);

            if (existingTaskItem == null)
                return null;

            // Optional: delete related entities if not using cascade delete
            _context.Attachments.RemoveRange(existingTaskItem.Attachments);
            _context.Comments.RemoveRange(existingTaskItem.Comments);
            _context.SprintTasks.RemoveRange(existingTaskItem.SprintTasks);
            _context.ActivityLogs.RemoveRange(existingTaskItem.ActivityLogs);

            _context.Tasks.Remove(existingTaskItem);

            return existingTaskItem;
        }

        public async Task<IEnumerable<Comment>> GetTaskComments(int taskId)
        {
            return await _context.Comments
                .Where(x => x.TaskItemId == taskId)
                .Include(t => t.User)
                .ToListAsync();
        }
    }
}

