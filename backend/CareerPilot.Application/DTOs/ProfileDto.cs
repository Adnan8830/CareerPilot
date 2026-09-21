namespace CareerPilot.Application.DTOs
{
    public class ProfileDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? LinkedInUrl { get; set; }

        public string? GitHubUrl { get; set; }

        public decimal YearsOfExperience { get; set; }
    }
}