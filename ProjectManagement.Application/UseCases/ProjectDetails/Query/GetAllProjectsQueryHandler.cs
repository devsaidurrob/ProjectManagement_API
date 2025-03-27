using MediatR;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Interfaces;
using ProjectManagement.Infrastructure.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Handlers
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, IEnumerable<Project>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            return await _projectRepository.GetAllProjectsAsync();
        }
    }
}
