using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.StoryDetails.Query
{
    public class GetStoriesByEpicIdQueryHandler : IRequestHandler<GetStoriesByEpicIdQuery, ResponseDto<IEnumerable<StoryDto>>>
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IMapper _mapper;

        public GetStoriesByEpicIdQueryHandler(IStoryRepository storyRepository, IMapper mapper)
        {
            _storyRepository = storyRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<IEnumerable<StoryDto>>> Handle(GetStoriesByEpicIdQuery request, CancellationToken cancellationToken)
        {
            var stories = await _storyRepository.GetStoriesByEpicIdAsync(request.EpicId);
            var storyDtos = _mapper.Map<IEnumerable<StoryDto>>(stories);
            return ResponseDto<IEnumerable<StoryDto>>.SuccessResponse(storyDtos);
        }
    }
}
