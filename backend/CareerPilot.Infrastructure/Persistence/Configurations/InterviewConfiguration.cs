using CareerPilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerPilot.Infrastructure.Persistence.Configurations
{
    public class InterviewConfiguration : IEntityTypeConfiguration<Interview>
    {
        public void Configure(EntityTypeBuilder<Interview> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.RoundType)
                   .IsRequired()
                   .HasConversion<int>();

            builder.Property(x => x.ScheduledDate)
            .IsRequired();

            builder.Property(x => x.Feedback)
                   .HasMaxLength(2000);



            builder.HasOne(x => x.JobApplication)
                   .WithMany(x => x.Interviews)
                   .HasForeignKey(x => x.JobApplicationId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}