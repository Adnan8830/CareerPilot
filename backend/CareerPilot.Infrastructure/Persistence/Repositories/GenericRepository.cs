using CareerPilot.Application.Interfaces.Repositories;
using CareerPilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace CareerPilot.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        private readonly CareerPilotDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(CareerPilotDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
       }
        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}