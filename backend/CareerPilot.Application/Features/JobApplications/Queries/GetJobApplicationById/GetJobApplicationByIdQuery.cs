using MediatR;
using CareerPilot.Application.DTOs;

namespace CareerPilot.Application.Features.JobApplications.Queries.GetJobApplicationById;

public record GetJobApplicationByIdQuery(Guid Id) : IRequest<JobApplicationDto>;
 

