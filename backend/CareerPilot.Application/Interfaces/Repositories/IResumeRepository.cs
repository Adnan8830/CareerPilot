using CareerPilot.Domain.Entities;

namespace CareerPilot.Application.Interfaces.Repositories
{
    public interface IResumeRepository : IGenericRepository<Resume>
    {
        Task<IEnumerable<Resume>> GetByUserIdAsync(Guid userId);

    }
}