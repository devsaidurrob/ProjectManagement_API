using ProjectManagement.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Interfaces
{
    public interface ISprintTaskRepository
    {
        Task<SprintTask?> GetSprintTaskByIdAsync(int id);
        Task<IEnumerable<SprintTask>> GetAllSprintTasksAsync();
        Task<IEnumerable<SprintTask>> GetSprintTasksBySprintIdAsync(int sprintId);
        Task<SprintTask> AddSprintTaskAsync(SprintTask sprintTask);
        Task<SprintTask?> UpdateSprintTaskAsync(SprintTask sprintTask);
        Task<SprintTask?> DeleteSprintTaskAsync(int id);
    }
}


