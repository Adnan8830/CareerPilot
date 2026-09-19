using CareerPilot.Application.DTOs;
using CareerPilot.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerPilot.Application.Features.JobApplications.Queries.GetJobApplicationsByStatus
{
    public record GetJobApplicationsByStatusQuery(
       ApplicationStatus Status
   ) : IRequest<IEnumerable<JobApplicationDto>>;
}
