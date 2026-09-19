using CareerPilot.Application.Interfaces.Repositories;
using CareerPilot.Domain.Entities;
using CareerPilot.Application.Interfaces.Repositories;
using CareerPilot.Domain.Entities;
using CareerPilot.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace CareerPilot.Infrastructure.Persistence.Repositories
{
    public class JobApplicationRepository :
        GenericRepository<JobApplication>, IJobApplicationRepository
    {
        private readonly CareerPilotDbContext _context;

        public JobApplicationRepository(CareerPilotDbContext dbContext)
           : base(dbContext)
        {
            _context = dbContext;
        }


        public async Task<IEnumerable<JobApplication>> GetByUserIdAsync(Guid userId) =>
             await _context.JobApplications.Where(x => x.UserId == userId).ToListAsync();

        public async Task<IEnumerable<JobApplication>> GetByStatusAsync(
             Guid userId,
            ApplicationStatus status) =>
            await _context.JobApplications.Where(x => string.Equals(x.Status, status) && x.UserId == userId).ToListAsync();





    }
}
