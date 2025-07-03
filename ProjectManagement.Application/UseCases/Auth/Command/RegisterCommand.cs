using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.Auth.Command
{
    public class RegisterCommand : IRequest<ResponseDto<AuthResultDto>>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int? CompanyId { get; set; } = 1; // Optional if single tenant
    }
}
