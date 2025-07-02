using Microsoft.IdentityModel.Tokens;
using ProjectManagement.Application.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectManagement.API.Utility
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(AuthResultDto user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("username", user.UserName),
                new Claim("fullname", user.FullName)
            };

            // Add roles claims if any
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var generatedToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(generatedToken);

            return token;
        }

        public bool ValidateToken(string token, out int userId)
        {
            userId = 0;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,  // optionally set issuer and audience if needed
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

                if (validatedToken is JwtSecurityToken jwtToken &&
                    jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    var userIdClaim = principal.FindFirst(JwtRegisteredClaimNames.Sub);
                    if (userIdClaim != null && int.TryParse(userIdClaim.Value, out userId))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                // Token invalid
            }

            return false;
        }
    }
}
