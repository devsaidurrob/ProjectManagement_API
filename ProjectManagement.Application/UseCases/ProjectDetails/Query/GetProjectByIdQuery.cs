using MediatR;
using ProjectManagement.Core.Entities;

namespace ProjectManagement.Infrastructure.Queries
{
    public class GetProjectByIdQuery : IRequest<Project>
    {
        public int Id { get; set; }

        public GetProjectByIdQuery(int id)
        {
            Id = id;
        }
    }
}
