using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.SprintDetails.Command
{
    public class CreateSprintCommand : IRequest<ResponseDto<SprintDto>>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectId { get; set; }

        public CreateSprintCommand(string name, DateTime startDate, DateTime endDate, int projectId)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            ProjectId = projectId;
        }
    }
}

