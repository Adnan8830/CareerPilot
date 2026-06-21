using Microsoft.EntityFrameworkCore;
using CareerPilot.Application.Interfaces.Repositories;
using CareerPilot.Domain.Entities;
using CareerPilot.Infrastructure.Persistence;

namespace CareerPilot.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly CareerPilotDbContext _context;

        public UserRepository(CareerPilotDbContext dbContext) : base(dbContext)
            => _context = dbContext;

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x=>x.Email==email);
        }
    }
}
