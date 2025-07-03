using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Core.Entities;

namespace ProjectManagement.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser?> GetUserByEmailAsync(string email);
        Task<AppUser?> GetUserByUserNameAsync(string email);
        Task<AppUser> AddUserAsync(AppUser user);
        Task<AppUser> UpdateUserAsync(AppUser user);
        Task<int> DeleteUserAsync(AppUser user);
        Task<IEnumerable<AppUser>> GetUsersByIdsAsync(IEnumerable<int> userIds);
        Task<AppUser?> FindByIdentifier(string identifier);
    }
}
