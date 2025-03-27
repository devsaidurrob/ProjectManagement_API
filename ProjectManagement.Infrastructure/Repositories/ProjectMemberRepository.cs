using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Data;
using ProjectManagement.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Repositories
{
    public class ProjectMemberRepository : IProjectMemberRepository
    {
        private readonly ProjectManagementDbContext _context;

        public ProjectMemberRepository(ProjectManagementDbContext context)
        {
            _context = context;
        }

        public async Task<ProjectMember?> GetProjectMemberByIdAsync(int id)
        {
            return await _context.ProjectMembers
                .Include(pm => pm.Project)
                .Include(pm => pm.User)
                .FirstOrDefaultAsync(pm => pm.Id == id);
        }

        public async Task<IEnumerable<ProjectMember>> GetAllProjectMembersAsync()
        {
            return await _context.ProjectMembers
                .Include(pm => pm.Project)
                .Include(pm => pm.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProjectMember>> GetProjectMembersByProjectIdAsync(int projectId)
        {
            return await _context.ProjectMembers
                .Where(pm => pm.ProjectId == projectId)
                .Include(pm => pm.Project)
                .Include(pm => pm.User)
                .ToListAsync();
        }

        public async Task<ProjectMember> AddProjectMemberAsync(ProjectMember projectMember)
        {
            await _context.ProjectMembers.AddAsync(projectMember);
            return projectMember;
        }

        public async Task<ProjectMember?> UpdateProjectMemberAsync(ProjectMember projectMember)
        {
            var existingProjectMember = await _context.ProjectMembers.FindAsync(projectMember.Id);

            if (existingProjectMember == null)
            {
                return null; // Or throw an exception
            }

            _context.Entry(existingProjectMember).CurrentValues.SetValues(projectMember);
            _context.Entry(existingProjectMember).State = EntityState.Modified;
            return existingProjectMember;
        }

        public async Task<ProjectMember?> DeleteProjectMemberAsync(int id)
        {
            var existingProjectMember = await _context.ProjectMembers.FindAsync(id);

            if (existingProjectMember == null)
            {
                return null; // Or throw an exception
            }

            _context.ProjectMembers.Remove(existingProjectMember);
            return existingProjectMember;
        }
    }
}

