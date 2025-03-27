using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Data;
using ProjectManagement.Infrastructure.Interfaces;

namespace ProjectManagement.Infrastructure.Repositories
{
    internal class SprintRepository : ISprintRepository
    {
        private readonly ProjectManagementDbContext _context;

        public SprintRepository(ProjectManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Sprint> GetSprintByIdAsync(int id)
        {
            return await _context.Sprints
                .Include(s => s.SprintTasks)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Sprint>> GetAllSprintsAsync()
        {
            return await _context.Sprints
                .Include(s => s.SprintTasks)
                .ToListAsync();
        }

        public async Task<IEnumerable<Sprint>> GetSprintsByProjectIdAsync(int projectId)
        {
            return await _context.Sprints
                .Where(s => s.ProjectId == projectId)
                .Include(s => s.SprintTasks)
                .ToListAsync();
        }

        public async Task<Sprint> AddSprintAsync(Sprint sprint)
        {
            await _context.Sprints.AddAsync(sprint);
            return sprint;
        }

        public async Task<Sprint> UpdateSprintAsync(Sprint sprint)
        {
            var existingSprint = await _context.Sprints.FindAsync(sprint.Id);

            if (existingSprint == null)
            {
                return null; // Or throw an exception
            }

            _context.Entry(existingSprint).CurrentValues.SetValues(sprint);
            _context.Entry(existingSprint).State = EntityState.Modified;
            return existingSprint;
        }

        public async Task<Sprint> DeleteSprintAsync(int id)
        {
            var existingSprint = await _context.Sprints.FindAsync(id);

            if (existingSprint == null)
            {
                return null; // Or throw an exception
            }

            _context.Sprints.Remove(existingSprint);
            return existingSprint;
        }
    }
}
