using CareerPilot.Domain.Common;
using CareerPilot.Domain.Enums;

namespace CareerPilot.Domain.Entities
{
    public class JobApplication : BaseEntity
    {
        public string CompanyName { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;

        public string JobUrl { get; set; } = string.Empty;

        public string? Notes { get; set; }

        public ApplicationStatus Status { get; set; }

        public string? ReferralName { get; set; }

        public string? ReferralLinkedInUrl { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; } = null!;

        public Guid ResumeId { get; set; }

        public Resume Resume { get; set; } = null!;

        public ICollection<Interview> Interviews { get; set; } = new List<Interview>();
    }
}