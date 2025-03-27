using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.StoryDetails.Command
{
    public class CreateStoryCommandHandler : IRequestHandler<CreateStoryCommand, ResponseDto<StoryDto>>
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStoryCommandHandler(IStoryRepository storyRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _storyRepository = storyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDto<StoryDto>> Handle(CreateStoryCommand request, CancellationToken cancellationToken)
        {
            var story = _mapper.Map<Story>(request);
            var addedStory = await _storyRepository.AddStoryAsync(story);
            await _unitOfWork.SaveChangesAsync();
            var storyDto = _mapper.Map<StoryDto>(addedStory);
            return ResponseDto<StoryDto>.SuccessResponse(storyDto);
        }
    }
}
