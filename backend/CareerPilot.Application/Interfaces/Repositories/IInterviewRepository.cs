using CareerPilot.Domain.Entities;

namespace CareerPilot.Application.Interfaces.Repositories
{
    public interface IInterviewRepository : IGenericRepository<Interview>
    {
        Task<IEnumerable<Interview>> GetByApplicationIdAsync(
            Guid applicationId);
    }
}