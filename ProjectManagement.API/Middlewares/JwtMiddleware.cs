using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectManagement.API.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _jwtSecret;

        public JwtMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _jwtSecret = config["Jwt:Key"]!;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Get the endpoint metadata
            var endpoint = context.GetEndpoint();

            // If endpoint has AllowAnonymous attribute, skip token validation
            var allowAnonymous = endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null;

            if (allowAnonymous)
            {
                await _next(context);
                return;
            }

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Token is missing");
                return; // short-circuit pipeline
            }

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_jwtSecret);

                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out SecurityToken _);

                // Log claims (UserId, Email, Role, etc.)
                var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var email = principal.FindFirst(ClaimTypes.Email)?.Value;
                var roles = principal.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();

                Console.WriteLine("🔐 JWT Token Info:");
                Console.WriteLine($"  UserId : {userId}");
                Console.WriteLine($"  Email  : {email}");
                Console.WriteLine($"  Roles  : {string.Join(", ", roles)}");

                // Optionally set user on context if needed:
                context.User = principal;
            }
            catch (SecurityTokenException ste)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                await context.Response.WriteAsync($"Invalid token: {ste.Message}");
                return; // short-circuit pipeline
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync($"Authentication error: {ex.Message}");
                return; // short-circuit pipeline
            }

            await _next(context);
        }
    }
}
