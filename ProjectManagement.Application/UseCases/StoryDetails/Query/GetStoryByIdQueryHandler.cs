using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.StoryDetails.Query
{
    public class GetStoryByIdQueryHandler : IRequestHandler<GetStoryByIdQuery, ResponseDto<StoryDto>>
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IMapper _mapper;

        public GetStoryByIdQueryHandler(IStoryRepository storyRepository, IMapper mapper)
        {
            _storyRepository = storyRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<StoryDto>> Handle(GetStoryByIdQuery request, CancellationToken cancellationToken)
        {
            var story = await _storyRepository.GetStoryByIdAsync(request.Id);
            if (story == null)
            {
                return ResponseDto<StoryDto>.ErrorResponse("Story not found", 404);
            }
            var storyDto = _mapper.Map<StoryDto>(story);
            return ResponseDto<StoryDto>.SuccessResponse(storyDto);
        }
    }
}
