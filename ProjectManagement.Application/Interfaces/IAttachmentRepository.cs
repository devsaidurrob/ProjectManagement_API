using ProjectManagement.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Interfaces
{
    public interface IAttachmentRepository
    {
        Task<Attachment?> GetAttachmentByIdAsync(int id);
        Task<IEnumerable<Attachment>> GetAllAttachmentsAsync();
        Task<IEnumerable<Attachment>> GetAttachmentsByTaskItemIdAsync(int taskItemId);
        Task<Attachment> AddAttachmentAsync(Attachment attachment);
        Task<Attachment?> UpdateAttachmentAsync(Attachment attachment);
        Task<Attachment?> DeleteAttachmentAsync(int id);
    }
}


