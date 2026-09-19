using MediatR;
using CareerPilot.Application.DTOs;
using CareerPilot.Application.Exceptions;
using CareerPilot.Application.Interfaces;
using CareerPilot.Application.Interfaces.Repositories;

namespace CareerPilot.Application.Features.JobApplications.Queries.GetJobApplicationById
{
    public class GetJobApplicationByIdQueryHandler : IRequestHandler<GetJobApplicationByIdQuery, JobApplicationDto>
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly ICurrentUserService _currentUserService;


        public GetJobApplicationByIdQueryHandler(
    IJobApplicationRepository jobApplicationRepository,
    ICurrentUserService currentUserService)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _currentUserService = currentUserService;
        }


        public async Task<JobApplicationDto> Handle(
            GetJobApplicationByIdQuery request,
            CancellationToken cancellationToken)
        {
            var application = await _jobApplicationRepository.GetByIdAsync(request.Id);

            if (application is null)
                throw new NotFoundException("Job application not found.");

            if (application.UserId != _currentUserService.UserId)
                throw new UnauthorizedException("You are not authorized to access this job application.");

            return new JobApplicationDto
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
            };
        }


    }
}
