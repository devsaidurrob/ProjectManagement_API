using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManagement.Core.Entities;

namespace ProjectManagement.Application.Interfaces
{
    public interface ISprintRepository
    {
        Task<Sprint> GetSprintByIdAsync(int id);
        Task<IEnumerable<Sprint>> GetAllSprintsAsync();
        Task<IEnumerable<Sprint>> GetSprintsByProjectIdAsync(int projectId);
        Task<Sprint> AddSprintAsync(Sprint sprint);
        Task<Sprint> UpdateSprintAsync(Sprint sprint);
        Task<Sprint> DeleteSprintAsync(int id);
    }
}
