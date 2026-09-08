using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerPilot.Domain.Entities;
using CareerPilot.Application.DTOs;

using MediatR;

namespace CareerPilot.Application.Features.Resumes.Queries.GetMyResume
{
    public class GetMyResumeQuery : IRequest<IEnumerable<ResumeDto>>
    {

    }
}
