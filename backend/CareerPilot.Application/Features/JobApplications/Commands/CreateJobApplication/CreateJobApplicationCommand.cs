using CareerPilot.Domain.Enums;
using MediatR;

namespace CareerPilot.Application.Features.JobApplications.Commands.CreateJobApplication;

public record CreateJobApplicationCommand(
    string CompanyName,
    string Position,
    string JobUrl,
    string? Notes,
    ApplicationStatus Status,
    string? ReferralName,
    string? ReferralLinkedInUrl,
    Guid ResumeId) : IRequest<Guid>;
    

