using ProjectManagement.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment?> GetCommentByIdAsync(int id);
        Task<IEnumerable<Comment>> GetAllCommentsAsync();
        Task<IEnumerable<Comment>> GetCommentsByTaskItemIdAsync(int taskItemId);
        Task<Comment> AddCommentAsync(Comment comment);
        Task<Comment?> UpdateCommentAsync(Comment comment);
        Task<Comment?> DeleteCommentAsync(int id);
    }
}


