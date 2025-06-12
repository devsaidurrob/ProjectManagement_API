using MediatR;
using ProjectManagement.Core.Entities;
using System.Collections.Generic;

namespace ProjectManagement.Application.UseCases.ProjectDetails.Query
{
    public class GetProjectByUserQuery : IRequest<IEnumerable<Project>>
    {
        public int UserId { get; set; }

        public GetProjectByUserQuery(int userId)
        {
            UserId = userId;
        }
    }
}
