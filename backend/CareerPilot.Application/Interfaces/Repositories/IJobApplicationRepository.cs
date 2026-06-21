using CareerPilot.Domain.Entities;
using CareerPilot.Domain.Enums;

namespace CareerPilot.Application.Interfaces.Repositories
{
    public interface IJobApplicationRepository : IGenericRepository<JobApplication>
    {
        Task<IEnumerable<JobApplication>> GetByUserIdAsync(Guid userId);

        Task<IEnumerable<JobApplication>> GetByStatusAsync(
            Guid userId,
            ApplicationStatus status);
    }
}