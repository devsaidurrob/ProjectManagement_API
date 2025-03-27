using MediatR;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Interfaces;
using ProjectManagement.Infrastructure.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Handlers
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Project>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Project> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            return await _projectRepository.GetProjectByIdAsync(request.Id);
        }
    }
}
