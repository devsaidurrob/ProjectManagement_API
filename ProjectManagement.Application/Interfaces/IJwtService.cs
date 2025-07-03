using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.Interfaces
{
    public interface IJwtService
    {
        /// <summary>
        /// Generates a JWT token for the given user ID.
        /// </summary>
        /// <param name="userId">The ID of the user for whom the token is generated.</param>
        /// <returns>A JWT token as a string.</returns>
        string GenerateToken(AuthResultDto user);
        /// <summary>
        /// Validates the provided JWT token.
        /// </summary>
        /// <param name="token">The JWT token to validate.</param>
        /// <returns>True if the token is valid; otherwise, false.</returns>
        bool ValidateToken(string token, out int userId);
        /// <summary>
        /// Extracts the user ID from the provided JWT token.
        /// </summary>
        /// <param name="token">The JWT token from which to extract the user ID.</param>
        /// <returns>The user ID if the token is valid; otherwise, null.</returns>
        int? GetUserIdFromToken(string token);
    }
}
