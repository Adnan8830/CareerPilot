using CareerPilot.Domain.Entities;
using CareerPilot.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerPilot.Infrastructure.Persistence.Configurations
{
    public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CompanyName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.Position)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.JobUrl)
                   .HasMaxLength(500);

            builder.Property(x => x.Notes)
                   .HasMaxLength(1000);

            builder.Property(x => x.Status)
                   .IsRequired()
                   .HasConversion<int>();

            // User relation
            builder.HasOne(x => x.User)
                   .WithMany(x=>x.JobApplications)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Resume relation
            builder.HasOne(x => x.Resume)
                   .WithMany()
                   .HasForeignKey(x => x.ResumeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}