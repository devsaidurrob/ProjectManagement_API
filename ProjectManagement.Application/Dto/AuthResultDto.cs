using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Dto
{
    public class AuthResultDto
    {
        public string? Token { get; set; } = null;
        //public string RefreshToken { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        [JsonIgnore]
        public string UserName { get; set; }
        [JsonIgnore]
        public string FullName { get; set; } = string.Empty;
        [JsonIgnore]
        public string Email { get; set; } = string.Empty;
        [JsonIgnore]
        public string[] Roles { get; set; } = Array.Empty<string>();
    }
}
