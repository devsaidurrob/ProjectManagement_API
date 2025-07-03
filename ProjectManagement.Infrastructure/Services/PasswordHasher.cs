using ProjectManagement.Application.Interfaces;
using ProjectManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Services
{
    internal class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password); // Using BCrypt for hashing
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            // Compare entered password with stored hash
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
