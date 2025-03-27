using MediatR;
using ProjectManagement.Core.Entities;
using System.Collections.Generic;

namespace ProjectManagement.Infrastructure.Queries
{
    public class GetAllProjectsQuery : IRequest<IEnumerable<Project>>
    {
    }
}
