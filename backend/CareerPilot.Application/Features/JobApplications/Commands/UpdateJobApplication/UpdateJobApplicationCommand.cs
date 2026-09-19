using CareerPilot.Domain.Enums;
using MediatR;

namespace CareerPilot.Application.Features.JobApplications.Commands.UpdateJobApplication
{
    public record UpdateJobApplicationCommand(
        Guid Id,
        string CompanyName,
        string Position,
        string JobUrl,
        string? Notes,
        ApplicationStatus Status,
        string? ReferralName,
        string? ReferralLinkedInUrl,
        Guid ResumeId) : IRequest;
    
}
