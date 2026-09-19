using CareerPilot.Domain.Entities;
using MediatR;
using CareerPilot.Application.DTOs;

namespace CareerPilot.Application.Features.JobApplications.Queries.GetMyJobApplications;
    public record GetMyJobApplicationsQuery : IRequest<IEnumerable<JobApplicationDto>>;
   
