using MediatR;

namespace CareerPilot.Application.Features.Resumes.Commands.DeleteResume;

    public record DeleteResumeCommand(Guid Id) : IRequest;
    

