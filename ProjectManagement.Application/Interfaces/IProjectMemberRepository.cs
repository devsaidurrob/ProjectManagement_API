using ProjectManagement.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Interfaces
{
    public interface IProjectMemberRepository
    {
        Task<ProjectMember?> GetProjectMemberByIdAsync(int id);
        Task<IEnumerable<ProjectMember>> GetAllProjectMembersAsync();
        Task<IEnumerable<ProjectMember>> GetProjectMembersByProjectIdAsync(int projectId);
        Task<ProjectMember> AddProjectMemberAsync(ProjectMember projectMember);
        Task<ProjectMember?> UpdateProjectMemberAsync(ProjectMember projectMember);
        Task<ProjectMember?> DeleteProjectMemberAsync(int id);
        Task<IEnumerable<ProjectMember>> AddProjectMembersAsync(IEnumerable<ProjectMember> projectMembers);
        IEnumerable<ProjectMember> RemoveProjectMembers(IEnumerable<ProjectMember> projectMembers);
    }
}
