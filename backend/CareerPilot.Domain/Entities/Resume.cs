using CareerPilot.Domain.Common;

namespace CareerPilot.Domain.Entities
{
    public class Resume : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public int Version { get; set; }
        public string FilePath { get; set; } = string.Empty;

        public Guid UserId { get; set; }

        public User User { get; set; } = null!;

    }
}