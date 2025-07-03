using MediatR;
using ProjectManagement.Core.Entities;
using ProjectManagement.Application.Interfaces;
using ProjectManagement.Application.UseCases.ProjectDetails.Query;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.ProjectDetails.Handlers
{
    public class GetProjectByUserQueryHandler : IRequestHandler<GetProjectByUserQuery, IEnumerable<Project>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectByUserQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> Handle(GetProjectByUserQuery request, CancellationToken cancellationToken)
        {
            return await _projectRepository.GetProjectByUser(request.UserId);
        }
    }
}
