using ProjectManagement.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Interfaces
{
    public interface IActivityLogRepository
    {
        Task<ActivityLog?> GetActivityLogByIdAsync(int id);
        Task<IEnumerable<ActivityLog>> GetAllActivityLogsAsync();
        Task<IEnumerable<ActivityLog>> GetActivityLogsByTaskItemIdAsync(int taskItemId);
        Task<ActivityLog> AddActivityLogAsync(ActivityLog activityLog);
        Task<ActivityLog?> UpdateActivityLogAsync(ActivityLog activityLog);
        Task<ActivityLog?> DeleteActivityLogAsync(int id);
    }
}


