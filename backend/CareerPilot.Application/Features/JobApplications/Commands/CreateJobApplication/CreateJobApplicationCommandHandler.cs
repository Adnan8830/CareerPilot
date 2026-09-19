using CareerPilot.Application.Exceptions;
using CareerPilot.Application.Interfaces;
using CareerPilot.Application.Interfaces.Repositories;
using CareerPilot.Domain.Entities;
using MediatR;

namespace CareerPilot.Application.Features.JobApplications.Commands.CreateJobApplication
{
    public class CreateJobApplicationCommandHandler : IRequestHandler<CreateJobApplicationCommand, Guid>
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IResumeRepository _resumeRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateJobApplicationCommandHandler(
            IJobApplicationRepository jobApplicationRepository,
            IResumeRepository resumeRepository,
            ICurrentUserService currentUserService,
            IUnitOfWork unitOfWork)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _resumeRepository = resumeRepository;
            _currentUserService = currentUserService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(
            CreateJobApplicationCommand request,
            CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var resume = await _resumeRepository.GetByIdAsync(request.ResumeId);

            if (resume is null || resume.UserId != userId)
                throw new UnauthorizedException(
                    "You are not authorized to use this resume.");

            var jobApplication = new JobApplication
            {
                CompanyName = request.CompanyName,
                Position = request.Position,
                JobUrl = request.JobUrl,
                Notes = request.Notes,
                Status = request.Status,
                ReferralName = request.ReferralName,
                ReferralLinkedInUrl = request.ReferralLinkedInUrl,
                UserId = userId,
                ResumeId = request.ResumeId
            };

            await _jobApplicationRepository.AddAsync(jobApplication);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return jobApplication.Id;
        }

    }
}
