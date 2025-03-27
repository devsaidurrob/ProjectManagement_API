using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.ProjectMemberDetails.Query
{
    public class GetAllProjectMembersQueryHandler : IRequestHandler<GetAllProjectMembersQuery, ResponseDto<IEnumerable<ProjectMemberDto>>>
    {
        private readonly IProjectMemberRepository _projectMemberRepository;
        private readonly IMapper _mapper;

        public GetAllProjectMembersQueryHandler(IProjectMemberRepository projectMemberRepository, IMapper mapper)
        {
            _projectMemberRepository = projectMemberRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<IEnumerable<ProjectMemberDto>>> Handle(GetAllProjectMembersQuery request, CancellationToken cancellationToken)
        {
            var projectMembers = await _projectMemberRepository.GetAllProjectMembersAsync();
            var projectMemberDtos = _mapper.Map<IEnumerable<ProjectMemberDto>>(projectMembers);
            return ResponseDto<IEnumerable<ProjectMemberDto>>.SuccessResponse(projectMemberDtos);
        }
    }
}
