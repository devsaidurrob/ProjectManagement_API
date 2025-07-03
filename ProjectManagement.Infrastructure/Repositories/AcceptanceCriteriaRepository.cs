using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Data;
using ProjectManagement.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Repositories
{
    public class AcceptanceCriteriaRepository : IAcceptanceCriteriaRepository
    {
        private readonly ProjectManagementDbContext _context;

        public AcceptanceCriteriaRepository(ProjectManagementDbContext context)
        {
            _context = context;
        }

        public async Task<AcceptanceCriteria?> GetAcceptanceCriteriaByIdAsync(int id)
        {
            return await _context.AcceptanceCriterias
                .Include(ac => ac.Story)
                .FirstOrDefaultAsync(ac => ac.Id == id);
        }

        public async Task<IEnumerable<AcceptanceCriteria>> GetAllAcceptanceCriteriasAsync()
        {
            return await _context.AcceptanceCriterias
                .Include(ac => ac.Story)
                .ToListAsync();
        }

        public async Task<IEnumerable<AcceptanceCriteria>> GetAcceptanceCriteriasByStoryIdAsync(int storyId)
        {
            return await _context.AcceptanceCriterias
                .Where(ac => ac.StoryId == storyId)
                .Include(ac => ac.Story)
                .ToListAsync();
        }

        public async Task<AcceptanceCriteria> AddAcceptanceCriteriaAsync(AcceptanceCriteria acceptanceCriteria)
        {
            await _context.AcceptanceCriterias.AddAsync(acceptanceCriteria);
            return acceptanceCriteria;
        }

        public async Task<AcceptanceCriteria?> UpdateAcceptanceCriteriaAsync(AcceptanceCriteria acceptanceCriteria)
        {
            var existingAcceptanceCriteria = await _context.AcceptanceCriterias.FindAsync(acceptanceCriteria.Id);

            if (existingAcceptanceCriteria == null)
            {
                return null; // Or throw an exception
            }

            _context.Entry(existingAcceptanceCriteria).CurrentValues.SetValues(acceptanceCriteria);
            _context.Entry(existingAcceptanceCriteria).State = EntityState.Modified;
            return existingAcceptanceCriteria;
        }

        public async Task<AcceptanceCriteria?> DeleteAcceptanceCriteriaAsync(int id)
        {
            var existingAcceptanceCriteria = await _context.AcceptanceCriterias.FindAsync(id);

            if (existingAcceptanceCriteria == null)
            {
                return null; // Or throw an exception
            }

            _context.AcceptanceCriterias.Remove(existingAcceptanceCriteria);
            return existingAcceptanceCriteria;
        }
    }
}



