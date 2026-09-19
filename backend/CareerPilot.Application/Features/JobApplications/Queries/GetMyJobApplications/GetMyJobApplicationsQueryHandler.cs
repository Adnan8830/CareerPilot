using CareerPilot.Application.DTOs;
using CareerPilot.Application.Interfaces;
using CareerPilot.Application.Interfaces.Repositories;
using MediatR;

namespace CareerPilot.Application.Features.JobApplications.Queries.GetMyJobApplications
{
    public class GetMyJobApplicationsQueryHandler : IRequestHandler<GetMyJobApplicationsQuery, IEnumerable<JobApplicationDto>>
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly ICurrentUserService _currentUserService;

        public GetMyJobApplicationsQueryHandler(
            IJobApplicationRepository jobApplicationRepository,
            ICurrentUserService currentUserService)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _currentUserService = currentUserService;
        }


        public async Task<IEnumerable<JobApplicationDto>> Handle(GetMyJobApplicationsQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;

            var applications = await _jobApplicationRepository
               .GetByUserIdAsync(userId);

            return applications.Select(application => new JobApplicationDto
            {
                Id = application.Id,
                CompanyName = application.CompanyName,
                Position = application.Position,
                JobUrl = application.JobUrl,
                Notes = application.Notes,
                Status = application.Status,
                ReferralName = application.ReferralName,
                ReferralLinkedInUrl = application.ReferralLinkedInUrl,
                ResumeId = application.ResumeId
            }).ToList();
        }

    }
}
