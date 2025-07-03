using ProjectManagement.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Interfaces
{
    public interface IStoryRepository
    {
        Task<Story?> GetStoryByIdAsync(int id);
        Task<IEnumerable<Story>> GetAllStoriesAsync();
        Task<IEnumerable<Story>> GetStoriesByEpicIdAsync(int epicId);
        Task<Story> AddStoryAsync(Story story);
        Task<Story?> UpdateStoryAsync(Story story);
        Task<Story?> DeleteStoryAsync(int id);
    }
}

