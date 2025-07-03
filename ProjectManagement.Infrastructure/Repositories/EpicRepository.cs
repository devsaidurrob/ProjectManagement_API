using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Data;
using ProjectManagement.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Repositories
{
    public class EpicRepository : IEpicRepository
    {
        private readonly ProjectManagementDbContext _context;

        public EpicRepository(ProjectManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Epic> GetEpicByIdAsync(int id)
        {
            return await _context.Epics.FindAsync(id);
        }

        public async Task<IEnumerable<Epic>> GetAllEpicsAsync()
        {
            return await _context.Epics.ToListAsync();
        }

        public async Task<Epic> AddEpicAsync(Epic epic)
        {
            await _context.Epics.AddAsync(epic);
            return epic;
        }

        public async Task<Epic> UpdateEpicAsync(Epic epic)
        {
            var existingEpic = await _context.Epics.FindAsync(epic.Id);

            if (existingEpic == null)
            {
                return null; // Or throw an exception
            }

            _context.Entry(existingEpic).CurrentValues.SetValues(epic);
            _context.Entry(existingEpic).State = EntityState.Modified;

            return existingEpic;
        }

        public async Task<Epic> DeleteEpicAsync(int id)
        {
            var epic = await GetEpicByIdAsync(id);
            if (epic != null)
            {
                _context.Epics.Remove(epic);
            }
            return epic;
        }

        public async Task<IEnumerable<Epic>> GetEpicsByProjectIdAsync(int projectId)
        {
            return await _context.Epics
                .Include(e => e.Stories)
                .Where(e => e.ProjectId == projectId)
                .ToListAsync();
        }
    }
}
