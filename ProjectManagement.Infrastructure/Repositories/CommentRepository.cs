using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Data;
using ProjectManagement.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ProjectManagementDbContext _context;

        public CommentRepository(ProjectManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Comment?> GetCommentByIdAsync(int id)
        {
            return await _context.Comments
                .Include(c => c.TaskItem)
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync()
        {
            return await _context.Comments
                .Include(c => c.TaskItem)
                .Include(c => c.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsByTaskItemIdAsync(int taskItemId)
        {
            return await _context.Comments
                .Where(c => c.TaskItemId == taskItemId)
                .Include(c => c.TaskItem)
                .Include(c => c.User)
                .ToListAsync();
        }

        public async Task<Comment> AddCommentAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            return comment;
        }

        public async Task<Comment?> UpdateCommentAsync(Comment comment)
        {
            var existingComment = await _context.Comments.FindAsync(comment.Id);

            if (existingComment == null)
            {
                return null; // Or throw an exception
            }

            _context.Entry(existingComment).CurrentValues.SetValues(comment);
            _context.Entry(existingComment).State = EntityState.Modified;
            return existingComment;
        }

        public async Task<Comment?> DeleteCommentAsync(int id)
        {
            var existingComment = await _context.Comments.FindAsync(id);

            if (existingComment == null)
            {
                return null; // Or throw an exception
            }

            _context.Comments.Remove(existingComment);
            return existingComment;
        }
    }
}


