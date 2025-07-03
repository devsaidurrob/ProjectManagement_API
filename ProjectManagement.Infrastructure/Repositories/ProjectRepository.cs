using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Data;
using ProjectManagement.Infrastructure.Interfaces;

namespace ProjectManagement.Infrastructure.Repositories
{
    internal class ProjectRepository : IProjectRepository
    {
        private readonly ProjectManagementDbContext _context;

        public ProjectRepository(ProjectManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _context.Projects
                .Include(p => p.Epics)
                .Include(p => p.Sprints)
                .Include(p => p.ProjectMembers)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects
                .Include(p => p.ProjectMembers)
                .ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetProjectByUser(int userId)
        {
            //return await _context.Projects
            //    .Where(p => p.OwnerId == userId)
            //    .Include(p => p.Epics)
            //    .Include(p => p.Sprints)
            //    .Include(p => p.ProjectMembers)
            //    .ToListAsync();
            return new List<Project>(); // Placeholder for actual implementation
        }

        public async Task<Project> AddProjectAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            return project;
        }

        public async Task<Project> UpdateProjectAsync(Project project)
        {
            var existingProject = await _context.Projects.FindAsync(project.Id);

            if (existingProject == null)
            {
                return null; // Or throw an exception
            }

            _context.Entry(existingProject).CurrentValues.SetValues(project);
            _context.Entry(existingProject).State = EntityState.Modified;

            return existingProject;
        }

        public async Task<Project> DeleteProjectAsync(int id)
        {
            var existingProject = await _context.Projects.FindAsync(id);

            if (existingProject == null)
            {
                return null; // Or throw an exception
            }

            _context.Projects.Remove(existingProject);
            return existingProject;
        }
    }
}
