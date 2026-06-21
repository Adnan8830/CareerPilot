using MediatR;

namespace CareerPilot.Application.Features.Resumes.Commands.CreateResume
{
    public record CreateResumeCommand(string Name,string FilePath) : IRequest<Guid>;
}
