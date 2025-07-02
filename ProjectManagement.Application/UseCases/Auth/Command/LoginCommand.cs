using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.Auth.Command
{
    public class LoginCommand : IRequest<ResponseDto<AuthResultDto>>
    {
        /// <summary>
        /// UserName can be Email, Mobile Number, or Username.
        /// </summary>
        public string UserName { get; set; } = string.Empty; // Email / Mobile / Username
        public string Password { get; set; } = string.Empty;
    }
}
