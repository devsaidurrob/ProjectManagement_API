using ProjectManagement.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Interfaces
{
    public interface ITaskItemRepository
    {
        Task<TaskItem?> GetTaskByIdAsync(int id);
        Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        Task<IEnumerable<TaskItem>> GetTasksByProjectAsync(int projectId);
        Task<IEnumerable<TaskItem>> GetTasksByStoryIdAsync(int storyId);
        Task<TaskItem> AddTaskAsync(TaskItem Tasks);
        Task<TaskItem?> UpdateTaskAsync(TaskItem Tasks);
        Task<TaskItem?> DeleteTaskAsync(int id);
        Task<IEnumerable<Comment>> GetTaskComments(int taskId);
    }
}

