using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Data;
using ProjectManagement.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Repositories
{
    public class StoryRepository : IStoryRepository
    {
        private readonly ProjectManagementDbContext _context;

        public StoryRepository(ProjectManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Story?> GetStoryByIdAsync(int id)
        {
            return await _context.Stories
                .Include(s => s.Tasks)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Story>> GetAllStoriesAsync()
        {
            return await _context.Stories
                .Include(s => s.Tasks)
                .ToListAsync();
        }

        public async Task<IEnumerable<Story>> GetStoriesByEpicIdAsync(int epicId)
        {
            return await _context.Stories
                .Where(s => s.EpicId == epicId)
                .Include(s => s.Tasks)
                .ToListAsync();
        }

        public async Task<Story> AddStoryAsync(Story story)
        {
            await _context.Stories.AddAsync(story);
            return story;
        }

        public async Task<Story?> UpdateStoryAsync(Story story)
        {
            var existingStory = await _context.Stories.FindAsync(story.Id);

            if (existingStory == null)
            {
                return null; // Or throw an exception
            }

            _context.Entry(existingStory).CurrentValues.SetValues(story);
            _context.Entry(existingStory).State = EntityState.Modified;
            return existingStory;
        }

        public async Task<Story?> DeleteStoryAsync(int id)
        {
            var existingStory = await _context.Stories.FindAsync(id);

            if (existingStory == null)
            {
                return null; // Or throw an exception
            }

            _context.Stories.Remove(existingStory);
            return existingStory;
        }
    }
}

