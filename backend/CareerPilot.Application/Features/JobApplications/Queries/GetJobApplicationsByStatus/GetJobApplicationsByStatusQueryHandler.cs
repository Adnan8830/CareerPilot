using CareerPilot.Application.DTOs;
using CareerPilot.Application.Interfaces;
using CareerPilot.Application.Interfaces.Repositories;
using MediatR;

namespace CareerPilot.Application.Features.JobApplications.Queries.GetJobApplicationsByStatus
{
    public class GetJobApplicationsByStatusQueryHandler
        : IRequestHandler<
            GetJobApplicationsByStatusQuery,
            IEnumerable<JobApplicationDto>>
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly ICurrentUserService _currentUserService;

        public GetJobApplicationsByStatusQueryHandler(
            IJobApplicationRepository jobApplicationRepository,
            ICurrentUserService currentUserService)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _currentUserService = currentUserService;
        }

        public async Task<IEnumerable<JobApplicationDto>> Handle(
            GetJobApplicationsByStatusQuery request,
            CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;

            var applications = await _jobApplicationRepository
                .GetByStatusAsync(userId, request.Status);

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