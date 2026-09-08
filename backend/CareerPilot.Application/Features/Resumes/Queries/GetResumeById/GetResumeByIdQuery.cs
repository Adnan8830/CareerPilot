using CareerPilot.Application.DTOs;
using MediatR;

namespace CareerPilot.Application.Features.Resumes.Queries.GetResumeById;

    public record GetResumeByIdQuery(Guid Id) :  IRequest<ResumeDto>
    {
    
    }
