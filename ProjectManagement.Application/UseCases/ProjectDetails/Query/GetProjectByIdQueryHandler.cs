using MediatR;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Interfaces;
using ProjectManagement.Application.UseCases.ProjectDetails.Query;
using System.Threading;
using System.Threading.Tasks;
using ProjectManagement.Application.Dto;
using AutoMapper;

namespace ProjectManagement.Application.UseCases.ProjectDetails.Handlers
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ResponseDto<ProjectDto>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        public GetProjectByIdQueryHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ProjectDto>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectByIdAsync(request.Id);
            var projectDto = _mapper.Map<ProjectDto>(project);
            return ResponseDto<ProjectDto>.SuccessResponse(projectDto);
        }
    }
}
