using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Data;
using ProjectManagement.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Repositories
{
    public class ActivityLogRepository : IActivityLogRepository
    {
        private readonly ProjectManagementDbContext _context;

        public ActivityLogRepository(ProjectManagementDbContext context)
        {
            _context = context;
        }

        public async Task<ActivityLog?> GetActivityLogByIdAsync(int id)
        {
            return await _context.ActivityLogs
                .Include(al => al.TaskItem)
                .Include(al => al.User)
                .FirstOrDefaultAsync(al => al.Id == id);
        }

        public async Task<IEnumerable<ActivityLog>> GetAllActivityLogsAsync()
        {
            return await _context.ActivityLogs
                .Include(al => al.TaskItem)
                .Include(al => al.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<ActivityLog>> GetActivityLogsByTaskItemIdAsync(int taskItemId)
        {
            return await _context.ActivityLogs
                .Where(al => al.TaskItemId == taskItemId)
                .Include(al => al.TaskItem)
                .Include(al => al.User)
                .ToListAsync();
        }

        public async Task<ActivityLog> AddActivityLogAsync(ActivityLog activityLog)
        {
            await _context.ActivityLogs.AddAsync(activityLog);
            return activityLog;
        }

        public async Task<ActivityLog?> UpdateActivityLogAsync(ActivityLog activityLog)
        {
            var existingActivityLog = await _context.ActivityLogs.FindAsync(activityLog.Id);

            if (existingActivityLog == null)
            {
                return null; // Or throw an exception
            }

            _context.Entry(existingActivityLog).CurrentValues.SetValues(activityLog);
            _context.Entry(existingActivityLog).State = EntityState.Modified;
            return existingActivityLog;
        }

        public async Task<ActivityLog?> DeleteActivityLogAsync(int id)
        {
            var existingActivityLog = await _context.ActivityLogs.FindAsync(id);

            if (existingActivityLog == null)
            {
                return null; // Or throw an exception
            }

            _context.ActivityLogs.Remove(existingActivityLog);
            return existingActivityLog;
        }
    }
}


