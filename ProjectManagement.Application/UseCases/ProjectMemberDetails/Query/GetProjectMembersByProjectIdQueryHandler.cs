using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.ProjectMemberDetails.Query
{
    public class GetProjectMembersByProjectIdQueryHandler : IRequestHandler<GetProjectMembersByProjectIdQuery, ResponseDto<IEnumerable<ProjectMemberDto>>>
    {
        private readonly IProjectMemberRepository _projectMemberRepository;
        private readonly IMapper _mapper;

        public GetProjectMembersByProjectIdQueryHandler(IProjectMemberRepository projectMemberRepository, IMapper mapper)
        {
            _projectMemberRepository = projectMemberRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<IEnumerable<ProjectMemberDto>>> Handle(GetProjectMembersByProjectIdQuery request, CancellationToken cancellationToken)
        {
            var projectMembers = await _projectMemberRepository.GetProjectMembersByProjectIdAsync(request.ProjectId);
            var projectMemberDtos = _mapper.Map<IEnumerable<ProjectMemberDto>>(projectMembers);
            return ResponseDto<IEnumerable<ProjectMemberDto>>.SuccessResponse(projectMemberDtos);
        }
    }
}
