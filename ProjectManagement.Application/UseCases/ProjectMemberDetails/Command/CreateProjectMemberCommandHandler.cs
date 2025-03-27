using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.ProjectMemberDetails.Command
{
    public class CreateProjectMemberCommandHandler : IRequestHandler<CreateProjectMemberCommand, ResponseDto<ProjectMemberDto>>
    {
        private readonly IProjectMemberRepository _projectMemberRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProjectMemberCommandHandler(IProjectMemberRepository projectMemberRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _projectMemberRepository = projectMemberRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ProjectMemberDto>> Handle(CreateProjectMemberCommand request, CancellationToken cancellationToken)
        {
            var projectMember = _mapper.Map<ProjectMember>(request);
            var addedProjectMember = await _projectMemberRepository.AddProjectMemberAsync(projectMember);
            await _unitOfWork.SaveChangesAsync();
            var projectMemberDto = _mapper.Map<ProjectMemberDto>(addedProjectMember);
            return ResponseDto<ProjectMemberDto>.SuccessResponse(projectMemberDto);
        }
    }
}
