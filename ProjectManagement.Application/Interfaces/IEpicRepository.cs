using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManagement.Core.Entities;

namespace ProjectManagement.Application.Interfaces
{
    public interface IEpicRepository
    {
        Task<Epic> GetEpicByIdAsync(int id);
        Task<IEnumerable<Epic>> GetAllEpicsAsync();
        Task<Epic> AddEpicAsync(Epic epic);
        Task<Epic> UpdateEpicAsync(Epic epic);
        Task<Epic> DeleteEpicAsync(int id);
        Task<IEnumerable<Epic>> GetEpicsByProjectIdAsync(int projectId);
    }
}
