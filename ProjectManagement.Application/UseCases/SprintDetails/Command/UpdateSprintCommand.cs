using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.SprintDetails.Command
{
    public class UpdateSprintCommand : IRequest<ResponseDto<SprintDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectId { get; set; }

        public UpdateSprintCommand(int id, string name, DateTime startDate, DateTime endDate, int projectId)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            ProjectId = projectId;
        }
    }
}

