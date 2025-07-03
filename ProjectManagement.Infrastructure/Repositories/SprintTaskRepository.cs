using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Data;
using ProjectManagement.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Repositories
{
    public class SprintTaskRepository : ISprintTaskRepository
    {
        private readonly ProjectManagementDbContext _context;

        public SprintTaskRepository(ProjectManagementDbContext context)
        {
            _context = context;
        }

        public async Task<SprintTask?> GetSprintTaskByIdAsync(int id)
        {
            return await _context.SprintTasks
                .Include(st => st.Sprint)
                .Include(st => st.TaskItem)
                .FirstOrDefaultAsync(st => st.Id == id);
        }

        public async Task<IEnumerable<SprintTask>> GetAllSprintTasksAsync()
        {
            return await _context.SprintTasks
                .Include(st => st.Sprint)
                .Include(st => st.TaskItem)
                .ToListAsync();
        }

        public async Task<IEnumerable<SprintTask>> GetSprintTasksBySprintIdAsync(int sprintId)
        {
            return await _context.SprintTasks
                .Where(st => st.SprintId == sprintId)
                .Include(st => st.Sprint)
                .Include(st => st.TaskItem)
                .ToListAsync();
        }

        public async Task<SprintTask> AddSprintTaskAsync(SprintTask sprintTask)
        {
            await _context.SprintTasks.AddAsync(sprintTask);
            return sprintTask;
        }

        public async Task<SprintTask?> UpdateSprintTaskAsync(SprintTask sprintTask)
        {
            var existingSprintTask = await _context.SprintTasks.FindAsync(sprintTask.Id);

            if (existingSprintTask == null)
            {
                return null; // Or throw an exception
            }

            _context.Entry(existingSprintTask).CurrentValues.SetValues(sprintTask);
            _context.Entry(existingSprintTask).State = EntityState.Modified;
            return existingSprintTask;
        }

        public async Task<SprintTask?> DeleteSprintTaskAsync(int id)
        {
            var existingSprintTask = await _context.SprintTasks.FindAsync(id);

            if (existingSprintTask == null)
            {
                return null; // Or throw an exception
            }

            _context.SprintTasks.Remove(existingSprintTask);
            return existingSprintTask;
        }
    }
}


