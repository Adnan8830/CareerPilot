using MediatR;

namespace CareerPilot.Application.Features.Profile.Commands.UpdateMyProfile;

public record UpdateMyProfileCommand(
    string FirstName,
    string LastName,
    string? LinkedInUrl,
    string? GitHubUrl,
    decimal YearsOfExperience
) : IRequest;