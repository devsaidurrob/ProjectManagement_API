using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Data;
using ProjectManagement.Application.Interfaces;

namespace ProjectManagement.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly ProjectManagementDbContext _context;
        public UserRepository(ProjectManagementDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
        {
            return await _context.Users
                .ToListAsync();
        }
        public async Task<AppUser> AddUserAsync(AppUser user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<int> DeleteUserAsync(AppUser user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser == null)
            {
                return 0;
            }

            _context.Users.Remove(existingUser);
            int retVal = await _context.SaveChangesAsync();
            return retVal;
        }

        public async Task<AppUser?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser?> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == userName);
        }

        public async Task<AppUser?> UpdateUserAsync(AppUser user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.FirstName = user.FirstName;
            existingUser.Email = user.Email;
            existingUser.PasswordHash = user.PasswordHash;
            //existingUser.Projects = user.Projects;

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();

            return existingUser;
        }
        public async Task<IEnumerable<AppUser>> GetUsersByIdsAsync(IEnumerable<int> userIds)
        {
            return await _context.Users
                .Where(u => userIds.Contains(u.Id))
                .ToListAsync();
        }
        public async Task<AppUser?> FindByIdentifier(string identifier)
        {
            return await _context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(r => r.Role)
                .FirstOrDefaultAsync(u =>
                    u.Email == identifier ||
                    u.MobileNumber == identifier ||
                    u.Username == identifier);
        }
    }
}
