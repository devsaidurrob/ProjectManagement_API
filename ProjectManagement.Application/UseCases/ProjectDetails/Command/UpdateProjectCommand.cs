namespace ProjectManagement.Application.UseCases.ProjectDetails.Commands
{
    public class UpdateProjectCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int OwnerId { get; set; }
    }
}
