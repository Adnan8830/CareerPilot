using CareerPilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareerPilot.Infrastructure.Persistence
{
    public class CareerPilotDbContext : DbContext
    {
        public CareerPilotDbContext(
            DbContextOptions<CareerPilotDbContext> options)
            : base(options)
        {
        }


        public DbSet<User> Users { get; set; }

        public DbSet<Resume> Resumes { get; set; }

        public DbSet<JobApplication> JobApplications { get; set; }

        public DbSet<Interview> Interviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(CareerPilotDbContext).Assembly);
        }

    }
}