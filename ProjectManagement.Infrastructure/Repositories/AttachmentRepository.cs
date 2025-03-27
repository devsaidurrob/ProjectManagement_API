using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Data;
using ProjectManagement.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Repositories
{
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly ProjectManagementDbContext _context;

        public AttachmentRepository(ProjectManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Attachment?> GetAttachmentByIdAsync(int id)
        {
            return await _context.Attachments
                .Include(a => a.TaskItem)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Attachment>> GetAllAttachmentsAsync()
        {
            return await _context.Attachments
                .Include(a => a.TaskItem)
                .ToListAsync();
        }

        public async Task<IEnumerable<Attachment>> GetAttachmentsByTaskItemIdAsync(int taskItemId)
        {
            return await _context.Attachments
                .Where(a => a.TaskItemId == taskItemId)
                .Include(a => a.TaskItem)
                .ToListAsync();
        }

        public async Task<Attachment> AddAttachmentAsync(Attachment attachment)
        {
            await _context.Attachments.AddAsync(attachment);
            return attachment;
        }

        public async Task<Attachment?> UpdateAttachmentAsync(Attachment attachment)
        {
            var existingAttachment = await _context.Attachments.FindAsync(attachment.Id);

            if (existingAttachment == null)
            {
                return null; // Or throw an exception
            }

            _context.Entry(existingAttachment).CurrentValues.SetValues(attachment);
            _context.Entry(existingAttachment).State = EntityState.Modified;
            return existingAttachment;
        }

        public async Task<Attachment?> DeleteAttachmentAsync(int id)
        {
            var existingAttachment = await _context.Attachments.FindAsync(id);

            if (existingAttachment == null)
            {
                return null; // Or throw an exception
            }

            _context.Attachments.Remove(existingAttachment);
            return existingAttachment;
        }
    }
}


