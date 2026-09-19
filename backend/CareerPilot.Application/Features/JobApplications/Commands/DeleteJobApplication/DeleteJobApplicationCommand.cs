using MediatR;


namespace CareerPilot.Application.Features.JobApplications.Commands.DeleteJobApplication
{
    public record DeleteJobApplicationCommand(Guid Id) : IRequest;
    
}
