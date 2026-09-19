using CareerPilot.Application.Exceptions;
using CareerPilot.Application.Interfaces;
using CareerPilot.Application.Interfaces.Repositories;
using CareerPilot.Application.Features.JobApplications.Commands.UpdateJobApplication;
using MediatR;

namespace CareerPilot.Application.Features.JobApplications.Commands.UpdateJobApplication
{
    public class UpdateJobApplicationCommandHandler : IRequestHandler<UpdateJobApplicationCommand>
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IResumeRepository _resumeRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateJobApplicationCommandHandler(
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

        public async Task Handle(
            UpdateJobApplicationCommand request,
            CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;

            var application = await _jobApplicationRepository
                .GetByIdAsync(request.Id) ?? throw new NotFoundException("Job application not found.");


            if (application.UserId != userId)
                throw new UnauthorizedException(
                    "You are not authorized to update this job application.");

            var resume = await _resumeRepository
                .GetByIdAsync(request.ResumeId);

            if (resume is null || resume.UserId != userId)
                throw new UnauthorizedException(
                    "You are not authorized to use this resume.");

            application.CompanyName = request.CompanyName;
            application.Position = request.Position;
            application.JobUrl = request.JobUrl;
            application.Notes = request.Notes;
            application.Status = request.Status;
            application.ReferralName = request.ReferralName;
            application.ReferralLinkedInUrl = request.ReferralLinkedInUrl;
            application.ResumeId = request.ResumeId;


            _jobApplicationRepository.Update(application);

            await _unitOfWork.SaveChangesAsync(cancellationToken);




        }
    }
}
