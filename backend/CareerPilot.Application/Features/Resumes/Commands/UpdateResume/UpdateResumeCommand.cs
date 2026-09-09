using MediatR;

namespace CareerPilot.Application.Features.Resumes.Commands.UpdateResume
{
    public record UpdateResumeCommand(
       Guid Id,
       string Name,
       string FilePath
   ) : IRequest;
}
