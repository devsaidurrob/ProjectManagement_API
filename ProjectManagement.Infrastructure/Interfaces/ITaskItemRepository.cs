using ProjectManagement.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Interfaces
{
    public interface ITaskItemRepository
    {
        Task<TaskItem?> GetTaskByIdAsync(int id);
        Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        Task<IEnumerable<TaskItem>> GetTasksByStoryIdAsync(int storyId);
        Task<TaskItem> AddTaskAsync(TaskItem Tasks);
        Task<TaskItem?> UpdateTaskAsync(TaskItem Tasks);
        Task<TaskItem?> DeleteTaskAsync(int id);
    }
}

