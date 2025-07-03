using ProjectManagement.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Interfaces
{
    public interface IAcceptanceCriteriaRepository
    {
        Task<AcceptanceCriteria?> GetAcceptanceCriteriaByIdAsync(int id);
        Task<IEnumerable<AcceptanceCriteria>> GetAllAcceptanceCriteriasAsync();
        Task<IEnumerable<AcceptanceCriteria>> GetAcceptanceCriteriasByStoryIdAsync(int storyId);
        Task<AcceptanceCriteria> AddAcceptanceCriteriaAsync(AcceptanceCriteria acceptanceCriteria);
        Task<AcceptanceCriteria?> UpdateAcceptanceCriteriaAsync(AcceptanceCriteria acceptanceCriteria);
        Task<AcceptanceCriteria?> DeleteAcceptanceCriteriaAsync(int id);
    }
}



