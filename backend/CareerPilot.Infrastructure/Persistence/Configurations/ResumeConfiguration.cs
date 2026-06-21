using CareerPilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerPilot.Infrastructure.Persistence.Configurations
{
    public class ResumeConfiguration : IEntityTypeConfiguration<Resume>
    {
        public void Configure(EntityTypeBuilder<Resume> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.FilePath)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(x => x.Version)
                   .IsRequired();

            builder.HasOne(x => x.User)
                   .WithMany(x => x.Resumes)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
           


        }
    }

}   