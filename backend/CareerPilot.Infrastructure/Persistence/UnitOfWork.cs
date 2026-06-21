using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerPilot.Application.Interfaces;
using CareerPilot.Infrastructure;

namespace CareerPilot.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CareerPilotDbContext _context;

        public UnitOfWork(CareerPilotDbContext context) => _context = context;


        public async Task<int>  SaveChangesAsync(CancellationToken cancellationToken = default) =>  
        await _context.SaveChangesAsync(cancellationToken);
        


    }
}
