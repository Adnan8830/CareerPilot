using CareerPilot.Domain.Common;
using CareerPilot.Domain.Enums;

namespace CareerPilot.Domain.Entities
{
    public class Interview : BaseEntity
    {
        public InterviewRoundType RoundType { get; set; }

        public DateTime ScheduledDate { get; set; }

        public string? Feedback { get; set; }

        public bool IsCompleted { get; set; }

        public Guid JobApplicationId { get; set; }

        public JobApplication JobApplication { get; set; } = null!;
    }
}