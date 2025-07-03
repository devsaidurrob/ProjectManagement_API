using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.ProjectMemberDetails.Query
{
    public class GetProjectMemberByIdQueryHandler : IRequestHandler<GetProjectMemberByIdQuery, ResponseDto<ProjectMemberDto>>
    {
        private readonly IProjectMemberRepository _projectMemberRepository;
        private readonly IMapper _mapper;

        public GetProjectMemberByIdQueryHandler(IProjectMemberRepository projectMemberRepository, IMapper mapper)
        {
            _projectMemberRepository = projectMemberRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ProjectMemberDto>> Handle(GetProjectMemberByIdQuery request, CancellationToken cancellationToken)
        {
            var projectMember = await _projectMemberRepository.GetProjectMemberByIdAsync(request.Id);
            if (projectMember == null)
            {
                return ResponseDto<ProjectMemberDto>.ErrorResponse("Project member not found", 404);
            }
            var projectMemberDto = _mapper.Map<ProjectMemberDto>(projectMember);
            return ResponseDto<ProjectMemberDto>.SuccessResponse(projectMemberDto);
        }
    }
}
