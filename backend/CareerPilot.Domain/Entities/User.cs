using CareerPilot.Domain.Common;

namespace CareerPilot.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string? LinkedInUrl { get; set; }

        public string? GitHubUrl { get; set; }

        public decimal YearsOfExperience { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<Resume> Resumes { get; set; } = new List<Resume>();

        public ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    }
}