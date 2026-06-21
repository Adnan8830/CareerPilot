using CareerPilot.Application.Interfaces.Repositories;
using CareerPilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CareerPilot.Infrastructure.Persistence.Repositories;

    public class ResumeRepository : GenericRepository<Resume>, IResumeRepository
    {
        private readonly CareerPilotDbContext _context;
        
        public ResumeRepository(CareerPilotDbContext dbContext) : base(dbContext) => _context = dbContext;
        
        public async Task<IEnumerable<Resume>> GetByUserIdAsync(Guid userId) => 
        await _context.Resumes.Where(r => r.UserId == userId).ToListAsync();
        


}

